using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class MySql:Form1
    {
       
        public void fieldEkle(string tabloadi, string fieldname, datatypes datatipi, int len = 0, int len1 = 0, bool required = false)
        {
            string definition = " NULL";
            if (required == true)
            {
                definition = " NOT NULL";
            }
            //string newcommandwp = "SET @dbname = DATABASE();SET @tablename = '" + tabloadi + "';SET @columnname = '" + fieldname + "';SET @preparedStatement = (SELECT IF(  (    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS    WHERE      (table_name = @tablename)      AND (table_schema = @dbname)      AND (column_name = @columnname)  ) > 0,  'SELECT 1',  CONCAT('ALTER TABLE ', @tablename, ' ADD ', @columnname, ' " + datatipi + ";')));PREPARE alterIfNotExists FROM @preparedStatement;EXECUTE alterIfNotExists;DEALLOCATE PREPARE alterIfNotExists;";
            //string newcommand1p = "SET @dbname = DATABASE();SET @tablename = '" + tabloadi + "';SET @columnname = '" + fieldname + "';SET @preparedStatement = (SELECT IF(  (    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS    WHERE      (table_name = @tablename)      AND (table_schema = @dbname)      AND (column_name = @columnname)  ) > 0,  'SELECT 1',  CONCAT('ALTER TABLE ', @tablename, ' ADD ', @columnname, ' " + datatipi + ";')));PREPARE alterIfNotExists FROM @preparedStatement;EXECUTE alterIfNotExists;DEALLOCATE PREPARE alterIfNotExists;";
            //string newcommand2p = "SET @dbname = DATABASE();SET @tablename = '" + tabloadi + "';SET @columnname = '" + fieldname + "';SET @preparedStatement = (SELECT IF(  (    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS    WHERE      (table_name = @tablename)      AND (table_schema = @dbname)      AND (column_name = @columnname)  ) > 0,  'SELECT 1',  CONCAT('ALTER TABLE ', @tablename, ' ADD ', @columnname, ' " + datatipi + ";')));PREPARE alterIfNotExists FROM @preparedStatement;EXECUTE alterIfNotExists;DEALLOCATE PREPARE alterIfNotExists;";
            MySqlConnection baglanti = new MySqlConnection(@"server=localhost;port=3306;database=database1_my;user=root;password=*********;Allow User Variables=True");
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand();
            komut.Connection = baglanti;
            switch (datatipi)
            {
                case datatypes.bit_:
                    try
                    {
                        komut.CommandText = "SET @dbname = 'database1_my'" + @";
                                         SET @tablename = '" + tabloadi + @"';
                                         SET @columnname = '" + fieldname + @"';
                                         SET @preparedStatement = (SELECT IF(  (    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS   " + @" 

                                         WHERE      (table_name = @tablename)      AND (table_schema = @dbname)      AND (column_name = @columnname)  ) > 0," + @" 

                                        'SELECT 1',   CONCAT('ALTER TABLE ', @tablename, ' ADD ', @columnname, ' BIT(" + len + ") ;')));" + @"

                                         PREPARE alterIfNotExists FROM @preparedStatement;" + @"
                                         EXECUTE alterIfNotExists;" + @"
                                         DEALLOCATE PREPARE alterIfNotExists;





                                        SET @dbname = 'database1_my'" + @";
                                        SET @tablename = '" + tabloadi + @"';
                                        SET @columnname = '" + fieldname + @"';
                                        SET @preparedStatement = (SELECT IF(  (    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS" + @"   
                                        
                                        WHERE      (table_name = @tablename)      AND (table_schema = @dbname)      AND (column_name = @columnname)  )  < 1," + @" 
                                        
                                        'SELECT 1',  CONCAT('ALTER TABLE ', @tablename, ' MODIFY ', @columnname, ' BIT(" + len + @") ;')));
                                        
                                        PREPARE alterIfNotExists FROM @preparedStatement;" + @"
                                        EXECUTE alterIfNotExists;" + @"
                                        DEALLOCATE PREPARE alterIfNotExists;";

                        komut.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        komut.CommandText = "SET @tmpGuid = REPLACE( uuid(),'-','');  SET @fieldName = concat('" + fieldname + @"' , '_' , @tmpGuid); 
                        select @fieldname;
                        SET @sql = CONCAT('ALTER TABLE " + tabloadi + " RENAME COLUMN " + fieldname + @" to ', @fieldName);

                        PREPARE dynamic_SQL FROM @sql;
                        EXECUTE dynamic_SQL;
                        DEALLOCATE PREPARE dynamic_SQL;

                        alter table " + tabloadi + " add column " + fieldname + " varchar(36)";
                        komut.ExecuteNonQuery();
                    }
                    
                    break;

                case datatypes.float_:
                    try
                    {
                        komut.CommandText = "SET @dbname ='database1_my';SET @tablename = '" + tabloadi + "';SET @columnname = '" + fieldname + "';SET @preparedStatement = (SELECT IF(  (    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS    WHERE      (table_name = @tablename)      AND (table_schema = @dbname)      AND (column_name = @columnname)  ) > 0,  'SELECT 1',  CONCAT('ALTER TABLE ', @tablename, ' ADD ', @columnname, ' FLOAT ;')));PREPARE alterIfNotExists FROM @preparedStatement;EXECUTE alterIfNotExists;DEALLOCATE PREPARE alterIfNotExists;                SET @dbname = 'database1_my';SET @tablename = '" + tabloadi + "';SET @columnname = '" + fieldname + "';SET @preparedStatement = (SELECT IF(  (    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS    WHERE      (table_name = @tablename)      AND (table_schema = @dbname)      AND (column_name = @columnname)  ) < 1,  'SELECT 1',  CONCAT('ALTER TABLE ', @tablename, ' MODIFY ', @columnname, ' FLOAT ;')));PREPARE alterIfNotExists FROM @preparedStatement;EXECUTE alterIfNotExists;DEALLOCATE PREPARE alterIfNotExists;        ";
                        komut.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        komut.CommandText = "SET @tmpGuid = REPLACE( uuid(),'-','');  SET @fieldName = concat('" + fieldname + @"' , '_' , @tmpGuid); 
                        select @fieldname;
                        SET @sql = CONCAT('ALTER TABLE " + tabloadi + " RENAME COLUMN " + fieldname + @" to ', @fieldName);

                        PREPARE dynamic_SQL FROM @sql;
                        EXECUTE dynamic_SQL;
                        DEALLOCATE PREPARE dynamic_SQL;

                        alter table " + tabloadi + " add column " + fieldname + " varchar(36)";
                        komut.ExecuteNonQuery();
                    }
                   
                    break;

                case datatypes.int_:
                    try
                    {
                        komut.CommandText = "SET @dbname = 'database1_my';SET @tablename = '" + tabloadi + "';SET @columnname = '" + fieldname + "';SET @preparedStatement = (SELECT IF(  (    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS    WHERE      (table_name = @tablename)      AND (table_schema = @dbname)      AND (column_name = @columnname)  ) > 0,  'SELECT 1',  CONCAT('ALTER TABLE ', @tablename, ' ADD ', @columnname, ' INT;')));PREPARE alterIfNotExists FROM @preparedStatement;EXECUTE alterIfNotExists;DEALLOCATE PREPARE alterIfNotExists;                   SET @dbname = 'database1_my';SET @tablename = '" + tabloadi + "';SET @columnname = '" + fieldname + "';SET @preparedStatement = (SELECT IF(  (    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS    WHERE      (table_name = @tablename)      AND (table_schema = @dbname)      AND (column_name = @columnname)  ) < 1,  'SELECT 1',  CONCAT('ALTER TABLE ', @tablename, ' MODIFY ', @columnname, ' INT;')));PREPARE alterIfNotExists FROM @preparedStatement;EXECUTE alterIfNotExists;DEALLOCATE PREPARE alterIfNotExists;     ";
                        komut.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        komut.CommandText = "SET @tmpGuid = REPLACE( uuid(),'-','');  SET @fieldName = concat('" + fieldname + @"' , '_' , @tmpGuid); 
                        select @fieldname;
                        SET @sql = CONCAT('ALTER TABLE " + tabloadi + " RENAME COLUMN " + fieldname + @" to ', @fieldName);

                        PREPARE dynamic_SQL FROM @sql;
                        EXECUTE dynamic_SQL;
                        DEALLOCATE PREPARE dynamic_SQL;

                        alter table " + tabloadi + " add column " + fieldname + " varchar(36)";
                        komut.ExecuteNonQuery();
                    }
                    
                    break;

                case datatypes.datetime_:
                    try
                    {
                        komut.CommandText = "SET @dbname = 'database1_my';SET @tablename = '" + tabloadi + "';SET @columnname = '" + fieldname + "';SET @preparedStatement = (SELECT IF(  (    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS    WHERE      (table_name = @tablename)      AND (table_schema = @dbname)      AND (column_name = @columnname)  ) > 0,  'SELECT 1',  CONCAT('ALTER TABLE ', @tablename, ' ADD ', @columnname, ' DATETIME;')));PREPARE alterIfNotExists FROM @preparedStatement;EXECUTE alterIfNotExists;DEALLOCATE PREPARE alterIfNotExists;              SET @dbname = 'database1_my';SET @tablename = '" + tabloadi + "';SET @columnname = '" + fieldname + "';SET @preparedStatement = (SELECT IF(  (    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS    WHERE      (table_name = @tablename)      AND (table_schema = @dbname)      AND (column_name = @columnname)  ) < 1,  'SELECT 1',  CONCAT('ALTER TABLE ', @tablename, ' MODIFY ', @columnname, ' DATETIME;')));PREPARE alterIfNotExists FROM @preparedStatement;EXECUTE alterIfNotExists;DEALLOCATE PREPARE alterIfNotExists;            ";
                        komut.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        komut.CommandText = "SET @tmpGuid = REPLACE( uuid(),'-','');  SET @fieldName = concat('" + fieldname + @"' , '_' , @tmpGuid); 
                        select @fieldname;
                        SET @sql = CONCAT('ALTER TABLE " + tabloadi + " RENAME COLUMN " + fieldname + @" to ', @fieldName);

                        PREPARE dynamic_SQL FROM @sql;
                        EXECUTE dynamic_SQL;
                        DEALLOCATE PREPARE dynamic_SQL;

                        alter table " + tabloadi + " add column " + fieldname + " varchar(36)";
                        komut.ExecuteNonQuery();
                    }
                     
                    break;

                case datatypes.date_:
                    try
                    {
                        komut.CommandText = "SET @dbname = 'database1_my';SET @tablename = '" + tabloadi + "';SET @columnname = '" + fieldname + "';SET @preparedStatement = (SELECT IF(  (    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS    WHERE      (table_name = @tablename)      AND (table_schema = @dbname)      AND (column_name = @columnname)  ) > 0,  'SELECT 1',  CONCAT('ALTER TABLE ', @tablename, ' ADD ', @columnname, ' DATE;')));PREPARE alterIfNotExists FROM @preparedStatement;EXECUTE alterIfNotExists;DEALLOCATE PREPARE alterIfNotExists;                  SET @dbname = 'database1_my';SET @tablename = '" + tabloadi + "';SET @columnname = '" + fieldname + "';SET @preparedStatement = (SELECT IF(  (    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS    WHERE      (table_name = @tablename)      AND (table_schema = @dbname)      AND (column_name = @columnname)  ) < 1,  'SELECT 1',  CONCAT('ALTER TABLE ', @tablename, ' MODIFY ', @columnname, ' DATE;')));PREPARE alterIfNotExists FROM @preparedStatement;EXECUTE alterIfNotExists;DEALLOCATE PREPARE alterIfNotExists;           ";
                        komut.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        komut.CommandText = "SET @tmpGuid = REPLACE( uuid(),'-','');  SET @fieldName = concat('" + fieldname + @"' , '_' , @tmpGuid); 
                        select @fieldname;
                        SET @sql = CONCAT('ALTER TABLE " + tabloadi + " RENAME COLUMN " + fieldname + @" to ', @fieldName);

                        PREPARE dynamic_SQL FROM @sql;
                        EXECUTE dynamic_SQL;
                        DEALLOCATE PREPARE dynamic_SQL;

                        alter table " + tabloadi + " add column " + fieldname + " varchar(36)";
                        komut.ExecuteNonQuery();
                    }
                   
                    break;

                case datatypes.time_:
                    try
                    {
                        komut.CommandText = "SET @dbname = 'database1_my';SET @tablename = '" + tabloadi + "';SET @columnname = '" + fieldname + "';SET @preparedStatement = (SELECT IF(  (    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS    WHERE      (table_name = @tablename)      AND (table_schema = @dbname)      AND (column_name = @columnname)  ) > 0,  'SELECT 1',  CONCAT('ALTER TABLE ', @tablename, ' ADD ', @columnname, ' TIME;')));PREPARE alterIfNotExists FROM @preparedStatement;EXECUTE alterIfNotExists;DEALLOCATE PREPARE alterIfNotExists                   SET @dbname = 'database1_my';SET @tablename = '" + tabloadi + "';SET @columnname = '" + fieldname + "';SET @preparedStatement = (SELECT IF(  (    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS    WHERE      (table_name = @tablename)      AND (table_schema = @dbname)      AND (column_name = @columnname)  ) < 1,  'SELECT 1',  CONCAT('ALTER TABLE ', @tablename, ' MODIFY ', @columnname, ' TIME;')));PREPARE alterIfNotExists FROM @preparedStatement;EXECUTE alterIfNotExists;DEALLOCATE PREPARE alterIfNotExists           ;";
                        komut.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        komut.CommandText = "SET @tmpGuid = REPLACE( uuid(),'-','');  SET @fieldName = concat('" + fieldname + @"' , '_' , @tmpGuid); 
                        select @fieldname;
                        SET @sql = CONCAT('ALTER TABLE " + tabloadi + " RENAME COLUMN " + fieldname + @" to ', @fieldName);

                        PREPARE dynamic_SQL FROM @sql;
                        EXECUTE dynamic_SQL;
                        DEALLOCATE PREPARE dynamic_SQL;

                        alter table " + tabloadi + " add column " + fieldname + " varchar(36)";
                        komut.ExecuteNonQuery();
                    }
                    
                    break;

                case datatypes.decimal_:
                    try
                    {
                        komut.CommandText = "SET @dbname = 'database1_my';SET @tablename = '" + tabloadi + "';SET @columnname = '" + fieldname + "';SET @preparedStatement = (SELECT IF(  (    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS    WHERE      (table_name = @tablename)      AND (table_schema = @dbname)      AND (column_name = @columnname)  ) > 0,  'SELECT 1',  CONCAT('ALTER TABLE ', @tablename, ' ADD ', @columnname, ' DECIMAL(" + len + ");')));PREPARE alterIfNotExists FROM @preparedStatement;EXECUTE alterIfNotExists;DEALLOCATE PREPARE alterIfNotExists;      SET @dbname = 'database1_my';SET @tablename = '" + tabloadi + "';SET @columnname = '" + fieldname + "';SET @preparedStatement = (SELECT IF(  (    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS    WHERE      (table_name = @tablename)      AND (table_schema = @dbname)      AND (column_name = @columnname)  ) < 1,  'SELECT 1',  CONCAT('ALTER TABLE ', @tablename, ' MODIFY ', @columnname, ' DECIMAL(" + len + ");')));PREPARE alterIfNotExists FROM @preparedStatement;EXECUTE alterIfNotExists;DEALLOCATE PREPARE alterIfNotExists;";
                        komut.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        komut.CommandText = "SET @tmpGuid = REPLACE( uuid(),'-','');  SET @fieldName = concat('" + fieldname + @"' , '_' , @tmpGuid); 
                        select @fieldname;
                        SET @sql = CONCAT('ALTER TABLE " + tabloadi + " RENAME COLUMN " + fieldname + @" to ', @fieldName);

                        PREPARE dynamic_SQL FROM @sql;
                        EXECUTE dynamic_SQL;
                        DEALLOCATE PREPARE dynamic_SQL;

                        alter table " + tabloadi + " add column " + fieldname + " varchar(36)";
                        komut.ExecuteNonQuery();
                    }
                    
                    break;
                case datatypes.char_:
                    try
                    {
                        komut.CommandText = "SET @dbname = 'database1_my';SET @tablename = '" + tabloadi + "';SET @columnname = '" + fieldname + "';SET @preparedStatement = (SELECT IF(  (    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS    WHERE      (table_name = @tablename)      AND (table_schema = @dbname)      AND (column_name = @columnname)  ) > 0,  'SELECT 1',  CONCAT('ALTER TABLE ', @tablename, ' ADD ', @columnname, ' CHAR(" + len + ");')));PREPARE alterIfNotExists FROM @preparedStatement;EXECUTE alterIfNotExists;DEALLOCATE PREPARE alterIfNotExists;          SET @dbname = 'database1_my';SET @tablename = '" + tabloadi + "';SET @columnname = '" + fieldname + "';SET @preparedStatement = (SELECT IF(  (    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS    WHERE      (table_name = @tablename)      AND (table_schema = @dbname)      AND (column_name = @columnname)  ) < 1,  'SELECT 1',  CONCAT('ALTER TABLE ', @tablename, ' MODIFY ', @columnname, ' CHAR(" + len + ");')));PREPARE alterIfNotExists FROM @preparedStatement;EXECUTE alterIfNotExists;DEALLOCATE PREPARE alterIfNotExists;   ";
                        komut.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        komut.CommandText = "SET @tmpGuid = REPLACE( uuid(),'-','');  SET @fieldName = concat('" + fieldname + @"' , '_' , @tmpGuid); 
                        select @fieldname;
                        SET @sql = CONCAT('ALTER TABLE " + tabloadi + " RENAME COLUMN " + fieldname + @" to ', @fieldName);

                        PREPARE dynamic_SQL FROM @sql;
                        EXECUTE dynamic_SQL;
                        DEALLOCATE PREPARE dynamic_SQL;

                        alter table " + tabloadi + " add column " + fieldname + " varchar(36)";
                        komut.ExecuteNonQuery();
                    }
                    
                    break;
                case datatypes.string_:
                    try
                    {
                        komut.CommandText = "SET @dbname = 'database1_my';SET @tablename = '" + tabloadi + "';SET @columnname = '" + fieldname + "';SET @preparedStatement = (SELECT IF(  (    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS    WHERE      (table_name = @tablename)      AND (table_schema = @dbname)      AND (column_name = @columnname)  ) > 0,  'SELECT 1',  CONCAT('ALTER TABLE ', @tablename, ' ADD ', @columnname, ' NVARCHAR(" + len + ");')));PREPARE alterIfNotExists FROM @preparedStatement;EXECUTE alterIfNotExists;DEALLOCATE PREPARE alterIfNotExists;       SET @dbname = 'database1_my';SET @tablename = '" + tabloadi + "';SET @columnname = '" + fieldname + "';SET @preparedStatement = (SELECT IF(  (    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS    WHERE      (table_name = @tablename)      AND (table_schema = @dbname)      AND (column_name = @columnname)  ) < 1,  'SELECT 1',  CONCAT('ALTER TABLE ', @tablename, ' MODIFY ', @columnname, ' NVARCHAR(" + len + ");')));PREPARE alterIfNotExists FROM @preparedStatement;EXECUTE alterIfNotExists;DEALLOCATE PREPARE alterIfNotExists;";
                        komut.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        komut.CommandText = "SET @tmpGuid = REPLACE( uuid(),'-','');  SET @fieldName = concat('" + fieldname + @"' , '_' , @tmpGuid); 
                        select @fieldname;
                        SET @sql = CONCAT('ALTER TABLE " + tabloadi + " RENAME COLUMN " + fieldname + @" to ', @fieldName);

                        PREPARE dynamic_SQL FROM @sql;
                        EXECUTE dynamic_SQL;
                        DEALLOCATE PREPARE dynamic_SQL;

                        alter table " + tabloadi + " add column " + fieldname + " varchar(36)";
                        komut.ExecuteNonQuery();
                    }
                    
                    break;

                case datatypes.bytearray_:
                    try
                    {
                        komut.CommandText = "SET @dbname = 'database1_my';SET @tablename = '" + tabloadi + "';SET @columnname = '" + fieldname + "';SET @preparedStatement = (SELECT IF(  (    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS    WHERE      (table_name = @tablename)      AND (table_schema = @dbname)      AND (column_name = @columnname)  ) > 0,  'SELECT 1',  CONCAT('ALTER TABLE ', @tablename, ' ADD ', @columnname, 'BLOB;')));PREPARE alterIfNotExists FROM @preparedStatement;EXECUTE alterIfNotExists;DEALLOCATE PREPARE alterIfNotExists;                     SET @dbname = 'database1_my';SET @tablename = '" + tabloadi + "';SET @columnname = '" + fieldname + "';SET @preparedStatement = (SELECT IF(  (    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS    WHERE      (table_name = @tablename)      AND (table_schema = @dbname)      AND (column_name = @columnname)  ) < 1,  'SELECT 1',  CONCAT('ALTER TABLE ', @tablename, ' MODIFY ', @columnname, 'BLOB;')));PREPARE alterIfNotExists FROM @preparedStatement;EXECUTE alterIfNotExists;DEALLOCATE PREPARE alterIfNotExists;";
                        komut.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        komut.CommandText = "SET @tmpGuid = REPLACE( uuid(),'-','');  SET @fieldName = concat('" + fieldname + @"' , '_' , @tmpGuid); 
                        select @fieldname;
                        SET @sql = CONCAT('ALTER TABLE " + tabloadi + " RENAME COLUMN " + fieldname + @" to ', @fieldName);

                        PREPARE dynamic_SQL FROM @sql;
                        EXECUTE dynamic_SQL;
                        DEALLOCATE PREPARE dynamic_SQL;

                        alter table " + tabloadi + " add column " + fieldname + " varchar(36)";
                        komut.ExecuteNonQuery();
                    }
                    
                    break;

                case datatypes.boolean_:
                    try
                    {
                        komut.CommandText = "SET @dbname = 'database1_my';SET @tablename = '" + tabloadi + "';SET @columnname = '" + fieldname + "';SET @preparedStatement = (SELECT IF(  (    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS    WHERE      (table_name = @tablename)      AND (table_schema = @dbname)      AND (column_name = @columnname)  ) > 0,  'SELECT 1',  CONCAT('ALTER TABLE ', @tablename, ' ADD ', @columnname, ' BOOLEAN;')));PREPARE alterIfNotExists FROM @preparedStatement;EXECUTE alterIfNotExists;DEALLOCATE PREPARE alterIfNotExists;                 SET @dbname = 'database1_my';SET @tablename = '" + tabloadi + "';SET @columnname = '" + fieldname + "';SET @preparedStatement = (SELECT IF(  (    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS    WHERE      (table_name = @tablename)      AND (table_schema = @dbname)      AND (column_name = @columnname)  ) < 1,  'SELECT 1',  CONCAT('ALTER TABLE ', @tablename, ' MODIFY ', @columnname, ' BOOLEAN;')));PREPARE alterIfNotExists FROM @preparedStatement;EXECUTE alterIfNotExists;DEALLOCATE PREPARE alterIfNotExists;  ";
                        komut.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        komut.CommandText = "SET @tmpGuid = REPLACE( uuid(),'-','');  SET @fieldName = concat('" + fieldname + @"' , '_' , @tmpGuid); 
                        select @fieldname;
                        SET @sql = CONCAT('ALTER TABLE " + tabloadi + " RENAME COLUMN " + fieldname + @" to ', @fieldName);

                        PREPARE dynamic_SQL FROM @sql;
                        EXECUTE dynamic_SQL;
                        DEALLOCATE PREPARE dynamic_SQL;

                        alter table " + tabloadi + " add column " + fieldname + " varchar(36)";
                        komut.ExecuteNonQuery();
                    }
                    
                    break;

                default:
                    break;
            }
           
            baglanti.Close();
        }


        public void tabloEkle(string tabloadi1)
        {
            string sorgu = "CREATE TABLE IF NOT EXISTS database1_my.`"+tabloadi1+"` (`"+tabloadi1+"PK` VARCHAR(36)  UNIQUE PRIMARY KEY);";
            MySqlConnection baglanti = new MySqlConnection(@"server=localhost;port=3306;database=database1_my;user=root;password=*********");
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand();
            komut.Connection = baglanti;
            komut.CommandText =sorgu;
            komut.ExecuteNonQuery();
            baglanti.Close();

        }

        public void fieldEkle_old(string tabloadi, string fieldname, datatypes datatipi, int len = 0, int len1 = 0, bool required = false)
        {
            string definition = " NULL";
            if (required == true)
            {
                definition = " NOT NULL";
            }

            MySqlConnection baglanti = new MySqlConnection(@"server=localhost;port=3306;database=database1_my;user=root;password=*********");
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand();
            komut.Connection = baglanti;
            switch (datatipi)
            {
                case datatypes.bit_:
                    komut.CommandText = "ALTER TABLE " + tabloadi + " ADD " + fieldname + " BIT(" + len + ")" + definition + ";";
                    break;

                case datatypes.float_:
                    komut.CommandText = "ALTER TABLE " + tabloadi + " ADD " + fieldname + " FLOAT" + definition + ";";
                    break;

                case datatypes.int_:
                    komut.CommandText = "ALTER TABLE " + tabloadi + " ADD " + fieldname + " INT " + definition + ";";
                    break;

                case datatypes.datetime_:
                    komut.CommandText = "ALTER TABLE " + tabloadi + " ADD " + fieldname + " DATETIME" + definition + ";";
                    break;

                case datatypes.date_:
                    komut.CommandText = "ALTER TABLE " + tabloadi + " ADD " + fieldname + " DATE" + definition + ";";
                    break;

                case datatypes.time_:
                    komut.CommandText = "ALTER TABLE " + tabloadi + " ADD " + fieldname + " TIME " + definition + ";";
                    break;

                case datatypes.decimal_:
                    komut.CommandText = "ALTER TABLE " + tabloadi + " ADD " + fieldname + " DECIMAL(" + len + ")" + definition + ";";
                    break;
                case datatypes.char_:
                    komut.CommandText = "ALTER TABLE " + tabloadi + " ADD " + fieldname + " CHAR(" + len + ")" + definition + ";";
                    break;
                case datatypes.string_:
                    komut.CommandText = "ALTER TABLE " + tabloadi + " ADD " + fieldname + " NVARCHAR(" + len + ")" + definition + ";";
                    break;

                case datatypes.bytearray_:
                    komut.CommandText = "ALTER TABLE " + tabloadi + " ADD " + fieldname + " BLOB " + definition + ";";
                    break;

                case datatypes.boolean_:
                    komut.CommandText = "ALTER TABLE " + tabloadi + " ADD COLUMN " + fieldname + " BOOLEAN";
                    break;

                default:
                    break;
            }
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public void foreignKeyEkle(string foreign_key, string primary_key, string tablenameFK, string tablenamePK)
        {
            MySqlConnection baglanti = new MySqlConnection(@"server=localhost;port=3306;database=database1_my;user=root;password=*********");
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "ALTER TABLE " + tablenameFK + " ADD " + foreign_key + " varchar(36) REFERENCES " + tablenamePK + "(" + primary_key + ");";
            komut.ExecuteNonQuery();
            baglanti.Close();

        }
        
        public void createDbEnum(string enum_, List<enumvalues> enumvalues)
        {
            tabloEkle(enum_);
            fieldEkle(enum_, "enumValue", datatypes.int_);
            fieldEkle(enum_, "enumName", datatypes.string_, 36);
            MySqlConnection baglanti = new MySqlConnection(@"server=localhost;port=3306;database=database1_my;user=root;password=*********");
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand();
            foreach (var item in enumvalues)
            {
                komut.Connection = baglanti;
                komut.CommandText = "insert into "+enum_+ "(" + enum_ + "PK,enumName,enumValue ) values (uuid(),@enumName,@enumValue);";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@enumValue", item.enumValue);
                komut.Parameters.AddWithValue("@enumName", item.EnumName);
                komut.ExecuteNonQuery();
            }
            komut = new MySqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = @"DELIMITER $$
                                USE `database1_my`$$
                                CREATE DEFINER =`root`@`localhost` FUNCTION `getNameOf"+enum_+@"`(enumV INT) RETURNS varchar(50) CHARSET utf8mb4
                                    DETERMINISTIC
                                BEGIN
                                DECLARE deger  varchar(50);
                                            SELECT
                                                enumName
                                INTO deger FROM
                                    "+enum_+@"
                                WHERE
                                    enumValue = enumV
                                LIMIT 1;
                                            RETURN deger;
                                            END$$

                                DELIMITER;
                                ";
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public void createFunction(string fonksiyonismi, string tabloadi)
        {
            var baglanti = new MySqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=database1;Persist Security Info=True;User Id =sa; Password=*********");
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = @"DELIMITER $$
                                USE `database1_my`$$
                                CREATE DEFINER =`root`@`localhost` FUNCTION `getNameOf" + tabloadi + @"`(enumV INT) RETURNS varchar(50) CHARSET utf8mb4
                                    DETERMINISTIC
                                BEGIN
                                DECLARE deger  varchar(50);
                                            SELECT
                                                enumName
                                INTO deger FROM
                                    " + tabloadi + @"
                                WHERE
                                    enumValue = enumV
                                LIMIT 1;
                                            RETURN deger;
                                            END$$

                                DELIMITER;
                                ";
            komut.ExecuteNonQuery();
            baglanti.Close();
        }




    }
}
