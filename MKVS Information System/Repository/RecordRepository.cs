using System;
using System.Data;
using System.Windows.Forms;
using MKVS_Information_System.Database;
using MKVS_Information_System.Models;
using MySql.Data.MySqlClient;

namespace MKVS_Information_System.Repository
{
    internal class RecordRepository
    {
        private readonly DatabaseConnection db = new DatabaseConnection();

        // ✅ Insert a new record
        public bool InsertRecord(Records record)
        {
            bool isSuccess = false;
            try
            {
                string query = @"INSERT INTO records 
                    (serial_no, date_received, first_name, middle_name, last_name, contact_no,
                     address_id, category, assistance_type, organization, event_name, event_date, 
                     event_venue, request_solicit, remarks, status)
                    VALUES
                    (@serial_no, @date_received, @first_name, @middle_name, @last_name, @contact_no,
                     @address_id, @category, @assistance_type, @organization, @event_name, @event_date, 
                     @event_venue, @request_solicit, @remarks, @status)";

                if (db.OpenConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, db.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@serial_no", record.SerialNo);
                        cmd.Parameters.AddWithValue("@date_received", record.DateReceived);
                        cmd.Parameters.AddWithValue("@first_name", record.FirstName);
                        cmd.Parameters.AddWithValue("@middle_name", record.MiddleName);
                        cmd.Parameters.AddWithValue("@last_name", record.LastName);
                        cmd.Parameters.AddWithValue("@contact_no", record.ContactNo);
                        cmd.Parameters.AddWithValue("@address_id", record.AddressId);
                        cmd.Parameters.AddWithValue("@category", record.Category);
                        cmd.Parameters.AddWithValue("@assistance_type", record.AssistanceType);
                        cmd.Parameters.AddWithValue("@organization", record.Organization);
                        cmd.Parameters.AddWithValue("@event_name", record.EventName);
                        cmd.Parameters.AddWithValue("@event_date", record.EventDate);
                        cmd.Parameters.AddWithValue("@event_venue", record.EventVenue);
                        cmd.Parameters.AddWithValue("@request_solicit", record.RequestSolicit);
                        cmd.Parameters.AddWithValue("@remarks", record.Remarks);
                        cmd.Parameters.AddWithValue("@status", record.Status);

                        int rows = cmd.ExecuteNonQuery();
                        isSuccess = rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting record:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseConnection();
            }

            return isSuccess;
        }

        // ✅ Insert or Retrieve Address ID
        public int GetOrInsertAddress(string barangayName, string addressNumber)
        {
            int addressId = 0;

            try
            {
                if (db.OpenConnection())
                {
                    // 1️⃣ Try to find the existing address
                    string selectQuery = "SELECT address_id FROM address WHERE barangay_name = @brgy AND address_number = @num LIMIT 1";
                    using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, db.GetConnection()))
                    {
                        selectCmd.Parameters.AddWithValue("@brgy", barangayName);
                        selectCmd.Parameters.AddWithValue("@num", addressNumber);

                        object result = selectCmd.ExecuteScalar();
                        if (result != null)
                        {
                            addressId = Convert.ToInt32(result);
                        }
                        else
                        {
                            // 2️⃣ Insert new address and retrieve new ID
                            string insertQuery = "INSERT INTO address (barangay_name, address_number) VALUES (@brgy, @num)";
                            using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, db.GetConnection()))
                            {
                                insertCmd.Parameters.AddWithValue("@brgy", barangayName);
                                insertCmd.Parameters.AddWithValue("@num", addressNumber);
                                insertCmd.ExecuteNonQuery();
                                addressId = (int)insertCmd.LastInsertedId; // ✅ Correct place to call it
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting/retrieving address:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseConnection();
            }

            return addressId;
        }
        public string GenerateSerialNumber()
        {
            string serial = "";
            string monthYear = DateTime.Now.ToString("MMyyyy"); // Example: 102025
            int nextNumber = 1;

            try
            {
                if (db.OpenConnection())
                {
                    using (var tran = db.GetConnection().BeginTransaction())
                    {
                        try
                        {
                            // Check if month entry exists
                            string selectQuery = "SELECT last_number FROM serial_tracker WHERE month_year = @monthYear LIMIT 1";
                            using (var cmdSelect = new MySqlCommand(selectQuery, db.GetConnection(), tran))
                            {
                                cmdSelect.Parameters.AddWithValue("@monthYear", monthYear);
                                object result = cmdSelect.ExecuteScalar();

                                if (result != null)
                                {
                                    // Existing month — increment
                                    nextNumber = Convert.ToInt32(result) + 1;

                                    string updateQuery = "UPDATE serial_tracker SET last_number = @num WHERE month_year = @monthYear";
                                    using (var cmdUpdate = new MySqlCommand(updateQuery, db.GetConnection(), tran))
                                    {
                                        cmdUpdate.Parameters.AddWithValue("@num", nextNumber);
                                        cmdUpdate.Parameters.AddWithValue("@monthYear", monthYear);
                                        cmdUpdate.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    // First serial for this month
                                    string insertQuery = "INSERT INTO serial_tracker (month_year, last_number) VALUES (@monthYear, @num)";
                                    using (var cmdInsert = new MySqlCommand(insertQuery, db.GetConnection(), tran))
                                    {
                                        cmdInsert.Parameters.AddWithValue("@monthYear", monthYear);
                                        cmdInsert.Parameters.AddWithValue("@num", nextNumber);
                                        cmdInsert.ExecuteNonQuery();
                                    }
                                }
                            }

                            // Commit the transaction — locks in your serial number safely
                            tran.Commit();

                            // Format the serial
                            serial = $"MKVS-{monthYear}-{nextNumber:D3}";
                        }
                        catch (Exception exInner)
                        {
                            tran.Rollback();
                            MessageBox.Show("Error during serial generation:\n" + exInner.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating serial number:\n" + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }

            return serial;
        }


        public string PeekNextSerialNumber()
        {
            string serial = "";
            string monthYear = DateTime.Now.ToString("MMyyyy"); // e.g. 112025
            int nextNumber = 1;

            try
            {
                if (db.OpenConnection())
                {
                    string query = "SELECT last_number FROM serial_tracker WHERE month_year = @monthYear LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, db.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@monthYear", monthYear);
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                            nextNumber = Convert.ToInt32(result) + 1; // just preview, not save
                    }

                    serial = $"MKVS-{monthYear}-{nextNumber:D3}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error previewing serial number:\n" + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }

            return serial;
        }




        public DataTable GetAllRecords(string search = "")
        {
            DataTable dt = new DataTable();

            try
            {
                if (db.OpenConnection())
                {
                    string query = @"
            SELECT 
                r.record_id AS 'Record ID',
                r.serial_no AS 'Serial No',
                r.status AS 'Status',
                r.date_received AS 'Date Received',
                r.first_name AS 'First Name',
                r.middle_name AS 'Middle Name',
                r.last_name AS 'Last Name',
                r.contact_no AS 'Contact No',
                a.barangay_name AS 'Barangay',
                a.address_number AS 'Address Info',
                r.category AS 'Category',
                r.assistance_type AS 'Assistance Type',
                r.organization AS 'Organization',
                r.event_name AS 'Event Name',
                r.event_date AS 'Event Date',
                r.event_venue AS 'Event Venue',
                r.request_solicit AS 'Request Type',
                r.remarks AS 'Remarks'
                
            FROM records r
            LEFT JOIN address a ON r.address_id = a.address_id
            WHERE r.first_name LIKE @search
               OR r.last_name LIKE @search
               OR r.serial_no LIKE @search
               OR r.category LIKE @search
            ORDER BY r.record_id DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, db.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@search", $"%{search}%");
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading records:\n" + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }

            return dt;
        }

        public DataTable SearchRecords(string search)
        {
            DataTable dt = new DataTable();

            try
            {
                if (db.OpenConnection())
                {
                    string query = @"
            SELECT 
                r.record_id AS 'Record ID',
                r.serial_no AS 'Serial No',
                r.status AS 'Status',
                r.date_received AS 'Date Received',
                r.first_name AS 'First Name',
                r.middle_name AS 'Middle Name',
                r.last_name AS 'Last Name',
                r.contact_no AS 'Contact No',
                a.barangay_name AS 'Barangay',
                a.address_number AS 'Address Info',
                r.category AS 'Category',
                r.assistance_type AS 'Assistance',
                r.organization AS 'Organization',
                r.event_name AS 'Event',
                r.event_date AS 'Event Date',
                r.event_venue AS 'Event Venue',
                r.request_solicit AS 'Request Solicit',
                r.remarks AS 'Remarks'
            FROM records r
            LEFT JOIN address a ON r.address_id = a.address_id
            WHERE 
                r.serial_no LIKE @search OR
                r.first_name LIKE @search OR
                r.middle_name LIKE @search OR
                r.last_name LIKE @search OR
                r.contact_no LIKE @search OR
                r.category LIKE @search OR
                r.assistance_type LIKE @search OR
                r.organization LIKE @search OR
                r.event_name LIKE @search OR
                r.event_venue LIKE @search OR
                r.request_solicit LIKE @search OR
                r.remarks LIKE @search OR
                r.status LIKE @search OR
                a.barangay_name LIKE @search OR
                a.address_number LIKE @search
            ORDER BY r.record_id DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, db.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching records:\n" + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }

            return dt;
        }


        public bool DeleteRecord(int recordId)
        {
            if (recordId <= 0)
            {
                MessageBox.Show("Invalid record id.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool success = false;

            try
            {
                if (db.OpenConnection())
                {
                    using (var tran = db.GetConnection().BeginTransaction())
                    {
                        try
                        {
                            int addressId = 0;

                            // 1) Get the linked address_id (if any)
                            using (var cmdGetAddress = new MySqlCommand("SELECT address_id FROM records WHERE record_id = @id", db.GetConnection(), tran))
                            {
                                cmdGetAddress.Parameters.AddWithValue("@id", recordId);
                                object result = cmdGetAddress.ExecuteScalar();
                                if (result != null)
                                    addressId = Convert.ToInt32(result);
                            }

                            // 2) Delete related payroll rows first (if any)
                            using (var cmdDelPayroll = new MySqlCommand("DELETE FROM payroll WHERE record_id = @id", db.GetConnection(), tran))
                            {
                                cmdDelPayroll.Parameters.AddWithValue("@id", recordId);
                                cmdDelPayroll.ExecuteNonQuery();
                            }

                            // 3) Delete the record itself
                            using (var cmdDelRecord = new MySqlCommand("DELETE FROM records WHERE record_id = @id", db.GetConnection(), tran))
                            {
                                cmdDelRecord.Parameters.AddWithValue("@id", recordId);
                                int rows = cmdDelRecord.ExecuteNonQuery();
                                success = rows > 0;
                            }

                            // 4) Delete the linked address (if found)
                            if (addressId > 0)
                            {
                                using (var cmdDelAddress = new MySqlCommand("DELETE FROM address WHERE address_id = @aid", db.GetConnection(), tran))
                                {
                                    cmdDelAddress.Parameters.AddWithValue("@aid", addressId);
                                    cmdDelAddress.ExecuteNonQuery();
                                }
                            }

                            tran.Commit();
                        }
                        catch (Exception exTran)
                        {
                            try { tran.Rollback(); } catch { /* ignore rollback error */ }
                            MessageBox.Show("Error deleting record (transaction):\n" + exTran.Message, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            success = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting record:\n" + ex.Message, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                success = false;
            }
            finally
            {
                db.CloseConnection();
            }

            return success;
        }


        public Records GetRecordBySerialNo(string serialNo)
        {
            Records record = null;

            try
            {
                if (db.OpenConnection())
                {
                    string query = @"
        SELECT 
            r.record_id,
            r.serial_no,
            r.date_received,
            r.first_name,
            r.middle_name,
            r.last_name,
            r.contact_no,
            r.category,
            r.assistance_type,
            r.organization,
            r.event_name,
            r.event_date,
            r.event_venue,
            r.request_solicit,
            r.remarks,
            r.status,
            r.address_id,
            a.barangay_name,
            a.address_number
        FROM records r
        LEFT JOIN address a ON r.address_id = a.address_id
        WHERE r.serial_no = @serialNo
        LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, db.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@serialNo", serialNo);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                record = new Records
                                {
                                    RecordId = reader["record_id"] != DBNull.Value ? Convert.ToInt32(reader["record_id"]) : 0,
                                    SerialNo = reader["serial_no"]?.ToString(),
                                    DateReceived = reader["date_received"]?.ToString(),
                                    FirstName = reader["first_name"]?.ToString(),
                                    MiddleName = reader["middle_name"]?.ToString(),
                                    LastName = reader["last_name"]?.ToString(),
                                    ContactNo = reader["contact_no"]?.ToString(),
                                    Category = reader["category"]?.ToString(),
                                    AssistanceType = reader["assistance_type"]?.ToString(),
                                    Organization = reader["organization"]?.ToString(),
                                    EventName = reader["event_name"]?.ToString(),
                                    EventDate = reader["event_date"]?.ToString(),
                                    EventVenue = reader["event_venue"]?.ToString(),
                                    RequestSolicit = reader["request_solicit"]?.ToString(),
                                    Remarks = reader["remarks"]?.ToString(),
                                    Status = reader["status"]?.ToString(),
                                    AddressId = reader["address_id"] != DBNull.Value ? Convert.ToInt32(reader["address_id"]) : 0,
                                    Barangay = reader["barangay_name"]?.ToString(),
                                    AdditionalInfo = reader["address_number"]?.ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching record:\n" + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseConnection();
            }

            return record;
        }


        public bool UpdateRecord(Records record)
        {
            bool isSuccess = false;

            try
            {
                if (db.OpenConnection())
                {
                    string query = @"
                UPDATE records
                SET 
                    first_name = @first_name,
                    middle_name = @middle_name,
                    last_name = @last_name,
                    contact_no = @contact_no,
                    address_id = @address_id,
                    category = @category,
                    assistance_type = @assistance_type,
                    organization = @organization,
                    event_name = @event_name,
                    event_date = @event_date,
                    event_venue = @event_venue,
                    request_solicit = @request_solicit,
                    remarks = @remarks,
                    status = @status
                WHERE serial_no = @serial_no";

                    using (MySqlCommand cmd = new MySqlCommand(query, db.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@first_name", record.FirstName);
                        cmd.Parameters.AddWithValue("@middle_name", record.MiddleName);
                        cmd.Parameters.AddWithValue("@last_name", record.LastName);
                        cmd.Parameters.AddWithValue("@contact_no", record.ContactNo);
                        cmd.Parameters.AddWithValue("@address_id", record.AddressId);
                        cmd.Parameters.AddWithValue("@category", record.Category);
                        cmd.Parameters.AddWithValue("@assistance_type", record.AssistanceType);
                        cmd.Parameters.AddWithValue("@organization", record.Organization);
                        cmd.Parameters.AddWithValue("@event_name", record.EventName);
                        cmd.Parameters.AddWithValue("@event_date", record.EventDate);
                        cmd.Parameters.AddWithValue("@event_venue", record.EventVenue);
                        cmd.Parameters.AddWithValue("@request_solicit", record.RequestSolicit);
                        cmd.Parameters.AddWithValue("@remarks", record.Remarks);
                        cmd.Parameters.AddWithValue("@status", record.Status);
                        cmd.Parameters.AddWithValue("@serial_no", record.SerialNo);

                        int rows = cmd.ExecuteNonQuery();
                        isSuccess = rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseConnection();
            }

            return isSuccess;
        }

        public bool DeleteRecord(string serialNo)
        {
            bool success = false;
            try
            {
                if (db.OpenConnection())
                {
                    // Get the record_id first
                    string getIdQuery = "SELECT record_id FROM records WHERE serial_no = @serialNo";
                    int recordId = 0;
                    using (MySqlCommand getCmd = new MySqlCommand(getIdQuery, db.GetConnection()))
                    {
                        getCmd.Parameters.AddWithValue("@serialNo", serialNo);
                        var result = getCmd.ExecuteScalar();
                        if (result != null) recordId = Convert.ToInt32(result);
                    }

                    // 1️⃣ Delete related payroll rows first
                    string deletePayrollQuery = "DELETE FROM payroll WHERE record_id = @recordId";
                    using (MySqlCommand delPayroll = new MySqlCommand(deletePayrollQuery, db.GetConnection()))
                    {
                        delPayroll.Parameters.AddWithValue("@recordId", recordId);
                        delPayroll.ExecuteNonQuery();
                    }

                    // 2️⃣ Now delete the record itself
                    string deleteRecordQuery = "DELETE FROM records WHERE serial_no = @serialNo";
                    using (MySqlCommand delRecord = new MySqlCommand(deleteRecordQuery, db.GetConnection()))
                    {
                        delRecord.Parameters.AddWithValue("@serialNo", serialNo);
                        int rows = delRecord.ExecuteNonQuery();
                        success = rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting record:\n" + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
            return success;
        }

        public bool UpdateAddress(int addressId, string barangayName, string addressNumber)
        {
            bool isSuccess = false;
            try
            {
                if (db.OpenConnection())
                {
                    string query = @"UPDATE address 
                             SET barangay_name = @brgy, address_number = @num 
                             WHERE address_id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, db.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@brgy", barangayName);
                        cmd.Parameters.AddWithValue("@num", addressNumber);
                        cmd.Parameters.AddWithValue("@id", addressId);

                        int rows = cmd.ExecuteNonQuery();
                        isSuccess = rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating address:\n" + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
            return isSuccess;
        }

        public DataTable GetFilteredRecords(RecordFilter filter)
        {
            DataTable dt = new DataTable();

            try
            {
                if (db.OpenConnection())
                {
                    string query = @"
                SELECT 
                    r.serial_no AS 'Serial No',
                    r.date_received AS 'Date Received',
                    r.first_name AS 'First Name',
                    r.middle_name AS 'Middle Name',
                    r.last_name AS 'Last Name',
                    r.contact_no AS 'Contact No',
                    a.barangay_name AS 'Barangay',
                    a.address_number AS 'Address Info',
                    r.category AS 'Category',
                    r.assistance_type AS 'Assistance Type',
                    r.organization AS 'Organization',
                    r.event_name AS 'Event Name',
                    r.event_date AS 'Event Date',
                    r.event_venue AS 'Event Venue',
                    r.request_solicit AS 'Request Type',
                    r.remarks AS 'Remarks',
                    r.status AS 'Status'
                FROM records r
                LEFT JOIN address a ON r.address_id = a.address_id
                WHERE 1=1";

                    // 🔹 Prepare filter parameters dynamically
                    List<MySqlParameter> parameters = new List<MySqlParameter>();

                    // 🗓 Date Range Filter
                    if (filter.FromDate.HasValue && filter.ToDate.HasValue)
                    {
                        query += " AND (r.event_date BETWEEN @from AND @to)";
                        parameters.Add(new MySqlParameter("@from", filter.FromDate.Value));
                        parameters.Add(new MySqlParameter("@to", filter.ToDate.Value));
                    }

                    // 🏘 Barangay Filter
                    if (!string.IsNullOrEmpty(filter.Barangay))
                    {
                        query += " AND a.barangay_name = @barangay";
                        parameters.Add(new MySqlParameter("@barangay", filter.Barangay));
                    }

                    // 🧾 Category Filter
                    if (!string.IsNullOrEmpty(filter.Category))
                    {
                        query += " AND r.category = @category";
                        parameters.Add(new MySqlParameter("@category", filter.Category));
                    }

                    // 💰 Assistance Type Filter
                    if (!string.IsNullOrEmpty(filter.AssistanceType))
                    {
                        query += " AND r.assistance_type = @assist";
                        parameters.Add(new MySqlParameter("@assist", filter.AssistanceType));
                    }

                    // 📋 Status Filter
                    if (!string.IsNullOrEmpty(filter.Status))
                    {
                        query += " AND r.status = @status";
                        parameters.Add(new MySqlParameter("@status", filter.Status));
                    }

                    // 🎄 Event Name Filter (case-insensitive, partial match)
                    if (!string.IsNullOrEmpty(filter.Event))
                    {
                        query += " AND LOWER(r.event_name) LIKE @eventName";
                        parameters.Add(new MySqlParameter("@eventName", "%" + filter.Event.ToLower() + "%"));
                    }

                    query += " ORDER BY r.record_id DESC";

                    // 🧩 Execute Query
                    using (MySqlCommand cmd = new MySqlCommand(query, db.GetConnection()))
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering records:\n" + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }

            return dt;
        }


        public DataTable SearchRecordsForPayroll(string search)
        {
            DataTable dt = new DataTable();
            try
            {
                if (db.OpenConnection())
                {
                    string query = @"
            SELECT 
                r.record_id AS 'Record ID',
                CONCAT(r.first_name, ' ', r.last_name) AS 'Full Name',
                a.barangay_name AS 'Barangay',
                r.contact_no AS 'Contact No',
                r.category AS 'Category',
                r.assistance_type AS 'Assistance',
                r.status AS 'Status'
            FROM records r
            LEFT JOIN address a ON r.address_id = a.address_id
            WHERE r.first_name LIKE @search OR r.last_name LIKE @search
            ORDER BY r.record_id DESC;";

                    using (MySqlCommand cmd = new MySqlCommand(query, db.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching records for payroll:\n" + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
            return dt;
        }

        public bool AddToPayroll(int recordId)
        {
            try
            {
                if (db.OpenConnection())
                {
                    // 🟣 1️⃣ Check if record already exists in payroll
                    string checkQuery = "SELECT COUNT(*) FROM payroll WHERE record_id = @recordId";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, db.GetConnection()))
                    {
                        checkCmd.Parameters.AddWithValue("@recordId", recordId);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("This record is already in payroll!");
                            return false;
                        }
                    }

                    // 🟢 2️⃣ Insert new payroll record with defaults
                    string insertQuery = "INSERT INTO payroll (record_id, gross_amount, exported) VALUES (@recordId, @grossAmount, @exported)";
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, db.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@recordId", recordId);
                        cmd.Parameters.AddWithValue("@grossAmount", "0");  // default
                        cmd.Parameters.AddWithValue("@exported", "No");    // default
                        cmd.ExecuteNonQuery();
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding to payroll:\n" + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }

            return false;
        }


        public DataTable GetAllPayrollRecords()
        {
            DataTable dt = new DataTable();

            try
            {
                if (db.OpenConnection())
                {
                    string query = @"
SELECT 
    p.payroll_id AS 'Payroll ID',
    CONCAT(r.first_name, ' ', r.middle_name, ' ', r.last_name) AS 'Full Name',
    a.barangay_name AS 'Barangay',
    r.contact_no AS 'Contact No',
    p.gross_amount AS 'Gross Amount',
    p.date_added AS 'Date Added',
    p.exported AS 'Exported'
FROM payroll p
INNER JOIN records r ON p.record_id = r.record_id
LEFT JOIN address a ON r.address_id = a.address_id
WHERE p.exported = 'No'
ORDER BY p.payroll_id DESC";


                    using (MySqlCommand cmd = new MySqlCommand(query, db.GetConnection()))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading payroll records:\n" + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }

            return dt;
        }



        // ✅ Get record_id using serial_no
        public int GetRecordIdBySerial(string serialNo)
        {
            int recordId = -1;
            try
            {
                if (db.OpenConnection())
                {
                    string query = "SELECT record_id FROM records WHERE serial_no = @serialNo LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, db.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@serialNo", serialNo);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                            recordId = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting record ID:\n" + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
            return recordId;
        }

        // ✅ Check if record is already in payroll
        public bool IsRecordInPayroll(int recordId)
        {
            bool exists = false;
            try
            {
                if (db.OpenConnection())
                {
                    string query = "SELECT COUNT(*) FROM payroll WHERE record_id = @recordId";
                    using (MySqlCommand cmd = new MySqlCommand(query, db.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@recordId", recordId);
                        exists = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking payroll record:\n" + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
            return exists;
        }

        // ✅ Delete payroll record
        public bool DeleteFromPayroll(int recordId)
        {
            bool deleted = false;
            try
            {
                if (db.OpenConnection())
                {
                    string query = "DELETE FROM payroll WHERE record_id = @recordId";
                    using (MySqlCommand cmd = new MySqlCommand(query, db.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@recordId", recordId);
                        deleted = cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting from payroll:\n" + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
            return deleted;
        }
        public bool UpdateRecordStatus(int recordId, string newStatus)
        {
            bool success = false;

            try
            {
                if (db.OpenConnection())
                {
                    string query = "UPDATE records SET status = @status WHERE record_id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, db.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@status", newStatus);
                        cmd.Parameters.AddWithValue("@id", recordId);
                        int rows = cmd.ExecuteNonQuery();
                        success = rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating status:\n" + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }

            return success;
        }

        public bool UpdateGrossAmount(int payrollId, string newAmount)
        {
            bool isSuccess = false;

            try
            {
                if (db.OpenConnection())
                {
                    string query = "UPDATE payroll SET gross_amount = @amount WHERE payroll_id = @payrollId";

                    using (MySqlCommand cmd = new MySqlCommand(query, db.GetConnection()))
                    {
                        cmd.Parameters.AddWithValue("@amount", newAmount);
                        cmd.Parameters.AddWithValue("@payrollId", payrollId);

                        int rows = cmd.ExecuteNonQuery();
                        isSuccess = rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating gross amount:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseConnection();
            }

            return isSuccess;
        }

    }
}
