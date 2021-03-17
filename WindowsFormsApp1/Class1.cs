using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace WindowsFormsApp1
{

    class MsSql : Form1
    {
        public void fieldEkle(string tabloadi, string fieldname, datatypes datatipi, int len = 0, int len1 = 0)//,int veritipi
        {
            // string fieldtype = ((datatypes)veritipi).ToString();
            SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=database1;Persist Security Info=True;User Id =sa; Password=Aa5715805");
            baglanti.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;

            switch (datatipi)
            {

                case datatypes.bit_:
                    komut.CommandText = "IF COL_LENGTH('" + tabloadi + "', '" + fieldname + @"') IS NOT NULL 
                                        BEGIN
	                                        BEGIN TRY
		                                        ALTER TABLE " + tabloadi + " ALTER COLUMN " + fieldname + @" bit  NULL;
	                                        END TRY
	                                        BEGIN CATCH

		                                        DECLARE @tmpGuid nvarchar(36);
		                                        DECLARE @fieldName nvarchar(100);
		                                        SELECT @tmpGuid = REPLACE(CONVERT(nvarchar(36), NEWID()),'-','');

		                                        SET @fieldName = '" + fieldname + @"'+ '_' + @tmpGuid;

		                                        EXEC sp_rename '" + tabloadi + "." + fieldname + @"', @fieldName,'COLUMN'
		                                        alter table " + tabloadi + " add " + fieldname + @" bit NULL

	                                        END CATCH
                                        END
                                        ELSE ALTER TABLE " + tabloadi + " add " + fieldname + @" bit NULL
                                        ";
                    break;

                case datatypes.float_:
                    komut.CommandText = "IF COL_LENGTH('" + tabloadi + "', '" + fieldname + @"') IS NOT NULL 
                                        BEGIN
	                                        BEGIN TRY
		                                        ALTER TABLE " + tabloadi + " ALTER COLUMN " + fieldname + @" float  NULL;
	                                        END TRY
	                                        BEGIN CATCH

		                                        DECLARE @tmpGuid nvarchar(36);
		                                        DECLARE @fieldName nvarchar(100);
		                                        SELECT @tmpGuid = REPLACE(CONVERT(nvarchar(36), NEWID()),'-','');

		                                        SET @fieldName = '" + fieldname + @"'+ '_' + @tmpGuid;

		                                        EXEC sp_rename '" + tabloadi + "." + fieldname + @"', @fieldName,'COLUMN'
		                                        alter table " + tabloadi + " add " + fieldname + @" float NULL

	                                        END CATCH
                                        END
                                        ELSE ALTER TABLE " + tabloadi + " add " + fieldname + @" float NULL
                                        ";
                    break;

                case datatypes.int_:
                    komut.CommandText = "IF COL_LENGTH('" + tabloadi + "', '" + fieldname + @"') IS NOT NULL 
                                        BEGIN
	                                        BEGIN TRY
		                                        ALTER TABLE " + tabloadi + " ALTER COLUMN " + fieldname + @" int  NULL;
	                                        END TRY
	                                        BEGIN CATCH

		                                        DECLARE @tmpGuid nvarchar(36);
		                                        DECLARE @fieldName nvarchar(100);
		                                        SELECT @tmpGuid = REPLACE(CONVERT(nvarchar(36), NEWID()),'-','');

		                                        SET @fieldName = '" + fieldname + @"'+ '_' + @tmpGuid;

		                                        EXEC sp_rename '" + tabloadi + "." + fieldname + @"', @fieldName,'COLUMN'
		                                        alter table " + tabloadi + " add " + fieldname + @" int NULL

	                                        END CATCH
                                        END
                                        ELSE ALTER TABLE " + tabloadi + " add " + fieldname + @" int NULL
                                        ";
                    break;

                case datatypes.date_:
                    komut.CommandText = "IF COL_LENGTH('" + tabloadi + "', '" + fieldname + @"') IS NOT NULL 
                                        BEGIN
	                                        BEGIN TRY
		                                        ALTER TABLE " + tabloadi + " ALTER COLUMN " + fieldname + @" DATE  NULL;
	                                        END TRY
	                                        BEGIN CATCH

		                                        DECLARE @tmpGuid nvarchar(36);
		                                        DECLARE @fieldName nvarchar(100);
		                                        SELECT @tmpGuid = REPLACE(CONVERT(nvarchar(36), NEWID()),'-','');

		                                        SET @fieldName = '" + fieldname + @"'+ '_' + @tmpGuid;

		                                        EXEC sp_rename '" + tabloadi + "." + fieldname + @"', @fieldName,'COLUMN'
		                                        alter table " + tabloadi + " add " + fieldname + @" DATE NULL

	                                        END CATCH
                                        END
                                        ELSE ALTER TABLE " + tabloadi + " add " + fieldname + @" DATE NULL
                                        ";
                    break;

                case datatypes.time_:
                    komut.CommandText = "IF COL_LENGTH('" + tabloadi + "', '" + fieldname + @"') IS NOT NULL 
                                        BEGIN
	                                        BEGIN TRY
		                                        ALTER TABLE " + tabloadi + " ALTER COLUMN " + fieldname + @" TIME  NULL;
	                                        END TRY
	                                        BEGIN CATCH

		                                        DECLARE @tmpGuid nvarchar(36);
		                                        DECLARE @fieldName nvarchar(100);
		                                        SELECT @tmpGuid = REPLACE(CONVERT(nvarchar(36), NEWID()),'-','');

		                                        SET @fieldName = '" + fieldname + @"'+ '_' + @tmpGuid;

		                                        EXEC sp_rename '" + tabloadi + "." + fieldname + @"', @fieldName,'COLUMN'
		                                        alter table " + tabloadi + " add " + fieldname + @" TIME NULL

	                                        END CATCH
                                        END
                                        ELSE ALTER TABLE " + tabloadi + " add " + fieldname + @" TIME NULL
                                        ";
                    break;

                case datatypes.datetime_:
                    komut.CommandText = "IF COL_LENGTH('" + tabloadi + "', '" + fieldname + @"') IS NOT NULL 
                                        BEGIN
	                                        BEGIN TRY
		                                        ALTER TABLE " + tabloadi + " ALTER COLUMN " + fieldname + @" datetime  NULL;
	                                        END TRY
	                                        BEGIN CATCH

		                                        DECLARE @tmpGuid nvarchar(36);
		                                        DECLARE @fieldName nvarchar(100);
		                                        SELECT @tmpGuid = REPLACE(CONVERT(nvarchar(36), NEWID()),'-','');

		                                        SET @fieldName = '" + fieldname + @"'+ '_' + @tmpGuid;

		                                        EXEC sp_rename '" + tabloadi + "." + fieldname + @"', @fieldName,'COLUMN'
		                                        alter table " + tabloadi + " add " + fieldname + @" datetime NULL

	                                        END CATCH
                                        END
                                        ELSE ALTER TABLE " + tabloadi + " add " + fieldname + @" datetime NULL
                                        ";
                    break;

                case datatypes.decimal_:
                    komut.CommandText = "IF COL_LENGTH('" + tabloadi + "', '" + fieldname + @"') IS NOT NULL 
                                        BEGIN
	                                        BEGIN TRY
		                                        ALTER TABLE " + tabloadi + " ALTER COLUMN " + fieldname + @" decimal(" + len + "," + len1 + @")  NULL;
	                                        END TRY
	                                        BEGIN CATCH

		                                        DECLARE @tmpGuid nvarchar(36);
		                                        DECLARE @fieldName nvarchar(100);
		                                        SELECT @tmpGuid = REPLACE(CONVERT(nvarchar(36), NEWID()),'-','');

		                                        SET @fieldName = '" + fieldname + @"'+ '_' + @tmpGuid;

		                                        EXEC sp_rename '" + tabloadi + "." + fieldname + @"', @fieldName,'COLUMN'
		                                        alter table " + tabloadi + " add " + fieldname + @" decimal(" + len + "," + len1 + @") NULL

	                                        END CATCH
                                        END
                                        ELSE ALTER TABLE " + tabloadi + " add " + fieldname + @" decimal(" + len + "," + len1 + @") NULL
                                        ";
                    break;

                case datatypes.char_:
                    komut.CommandText = "IF COL_LENGTH('" + tabloadi + "', '" + fieldname + @"') IS NOT NULL 
                                        BEGIN
	                                        BEGIN TRY
		                                        ALTER TABLE " + tabloadi + " ALTER COLUMN " + fieldname + @" char(" + len + @")  NULL;
	                                        END TRY
	                                        BEGIN CATCH

		                                        DECLARE @tmpGuid nvarchar(36);
		                                        DECLARE @fieldName nvarchar(100);
		                                        SELECT @tmpGuid = REPLACE(CONVERT(nvarchar(36), NEWID()),'-','');

		                                        SET @fieldName = '" + fieldname + @"'+ '_' + @tmpGuid;

		                                        EXEC sp_rename '" + tabloadi + "." + fieldname + @"', @fieldName,'COLUMN'
		                                        alter table " + tabloadi + " add " + fieldname + @" char(" + len + @") NULL

	                                        END CATCH
                                        END
                                        ELSE ALTER TABLE " + tabloadi + " add " + fieldname + @" char(" + len + @") NULL
                                        ";
                    break;

                case datatypes.string_:
                    komut.CommandText = "IF COL_LENGTH('" + tabloadi + "', '" + fieldname + @"') IS NOT NULL 
                                        BEGIN
	                                        BEGIN TRY
		                                        ALTER TABLE " + tabloadi + " ALTER COLUMN " + fieldname + @" nvarchar(" + len + @")  NULL;
	                                        END TRY
	                                        BEGIN CATCH

		                                        DECLARE @tmpGuid nvarchar(36);
		                                        DECLARE @fieldName nvarchar(100);
		                                        SELECT @tmpGuid = REPLACE(CONVERT(nvarchar(36), NEWID()),'-','');

		                                        SET @fieldName = '" + fieldname + @"'+ '_' + @tmpGuid;

		                                        EXEC sp_rename '" + tabloadi + "." + fieldname + @"', @fieldName,'COLUMN'
		                                        alter table " + tabloadi + " add " + fieldname + @" nvarchar(" + len + @") NULL

	                                        END CATCH
                                        END
                                        ELSE ALTER TABLE " + tabloadi + " add " + fieldname + @" nvarchar(" + len + @") NULL
                                        ";
                    break;

                case datatypes.bytearray_:
                    komut.CommandText = "IF COL_LENGTH('" + tabloadi + "', '" + fieldname + @"') IS NOT NULL 
                                        BEGIN
	                                        BEGIN TRY
		                                        ALTER TABLE " + tabloadi + " ALTER COLUMN " + fieldname + @" binary(" + len + @")  NULL;
	                                        END TRY
	                                        BEGIN CATCH

		                                        DECLARE @tmpGuid nvarchar(36);
		                                        DECLARE @fieldName nvarchar(100);
		                                        SELECT @tmpGuid = REPLACE(CONVERT(nvarchar(36), NEWID()),'-','');

		                                        SET @fieldName = '" + fieldname + @"'+ '_' + @tmpGuid;

		                                        EXEC sp_rename '" + tabloadi + "." + fieldname + @"', @fieldName,'COLUMN'
		                                        alter table " + tabloadi + " add " + fieldname + @" binary(" + len + @") NULL

	                                        END CATCH
                                        END
                                        ELSE ALTER TABLE " + tabloadi + " add " + fieldname + @" binary(" + len + @") NULL
                                        ";
                    break;

                default:
                    break;
            }
            komut.ExecuteNonQuery();
            baglanti.Close();

        }
        public void tabloEkle(string tabloadi)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=database1;Persist Security Info=True;User Id =sa; Password=Aa5715805");
            baglanti.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'" + tabloadi + "')BEGIN CREATE TABLE " + tabloadi + "(" + tabloadi + "PK" + " uniqueidentifier NOT NULL  PRIMARY KEY(" + tabloadi + "PK)); END";
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public void foreignKeyEkle(string foreign_key, string primary_key, string tablenameFK, string tablenamePK)
        {
            var baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=database1;Persist Security Info=True;User Id =sa; Password=Aa5715805");
            baglanti.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "ALTER TABLE " + tablenameFK + " ADD " + foreign_key + " UNIQUEIDENTIFIER REFERENCES " + tablenamePK + "(" + primary_key + ");";
            komut.ExecuteNonQuery();
            baglanti.Close();
        }


        public void createDbEnum(string enum_, List<enumvalues> enumvalues)
        {
            tabloEkle(enum_);
            fieldEkle(enum_, "enumValue", datatypes.int_);
            fieldEkle(enum_, "enumName", datatypes.string_, 36);
            SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=database1;Persist Security Info=True;User Id =sa; Password=Aa5715805");
            baglanti.Open();
            SqlCommand komut = new SqlCommand();
            foreach (var item in enumvalues)
            {

                komut.Connection = baglanti;
                komut.CommandText = "insert into " + enum_ + " (" + enum_ + "PK,enumName,enumValue ) values (NEWID(),@enumName,@enumValue);";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@enumName", item.EnumName);
                komut.Parameters.AddWithValue("@enumValue", item.enumValue);

                komut.ExecuteNonQuery();
            }

            komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "create function getNameOf" + enum_ + @"(@gelendeger int)
                                returns varchar(50)
                                as
                                begin
                                declare @deger varchar(50)

                                select @deger = (SELECT TOP 1 enumname from " + enum_ + @" where enumValue = @gelendeger)
                                return @deger
                                end";
            komut.ExecuteNonQuery();

            baglanti.Close();
        }


        public void createFunction(string fonksiyonismi, string tabloadi)
        {
            var baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=database1;Persist Security Info=True;User Id =sa; Password=Aa5715805");
            baglanti.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "create function "+fonksiyonismi+@"(@gelendeger int)
                                returns varchar(50)
                                as
                                begin
                                declare @deger varchar(50)

                                select @deger = enumname from "+tabloadi+@" where enumValue = @gelendeger
                                return @deger
                                end";
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
