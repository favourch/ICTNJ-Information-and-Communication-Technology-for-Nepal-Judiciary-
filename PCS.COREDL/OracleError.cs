using System;

/// <summary>
/// Created Date : 28-06-2009 
/// Created By   : Iltaf Hussain
/// Objective    : To Show Oracle Error Message 
/// </summary>
/// 
namespace PCS.COREDL
{
    public class OracleError
    {
        public string GetOraError(long lngOraErrorNo,string strError)
        {
            string strErrorMsg = "";
            //strError = "";
            //string strErSubMsg = "";
            switch (lngOraErrorNo)
            {
                case 1400:
                    //strErSubMsg= 
                    strErrorMsg = "Error:cannot insert NULL into (string)" + "\n";
                    strErrorMsg = strErrorMsg + "Cause: An attempt was made to insert a NULL into the column USER.TABLE.COLUMN" + "\n";
                    strErrorMsg = strErrorMsg + "Action: Retry the operation with a value other than NULL";;
                    break;
                case 1401:
                    strErrorMsg = "Error: inserted value too large for column\n";
                    strErrorMsg = strErrorMsg + "Cause: The value entered is larger than the maximum width defined for the column.\n";
                    strErrorMsg = strErrorMsg + "Action: Enter a value smaller than the column width or use the MODIFY option with ALTER TABLE to expand the column width";;
                    break;
                
                case 1402:
                    strErrorMsg = "Error: view WITH CHECK OPTION where-clause violation\n";
                    strErrorMsg = strErrorMsg + "Cause: An INSERT or UPDATE statement was attempted on a view created with the CHECK OPTION. This would have resulted in the creation of a row that would not satisfy the view's WHERE clause.\n";
                    strErrorMsg = strErrorMsg + "Action: Examine the view's WHERE clause in the dictionary table VIEWS. If the current view does not have the CHECK OPTION,: its FROM clause must reference a second view that is defined using the CHECK OPTION. The second view's WHERE clause must also be satisfied by any INSERT or UPDATE statements. To insert the row, it may be necessary to insert it directly into the underlying table, rather than through the view";
                    break;
                case 1403:
                    strErrorMsg = "Error:no data found\n";
                    strErrorMsg = strErrorMsg + "Cause: In a host language program, all records have been fetched. The return code from the fetch was +4, indicating that all records have been returned from the SQL query.\n";
                    strErrorMsg = strErrorMsg + "Action: Terminate processing for the SELECT statement";
                    break;
                case 1404:
                    strErrorMsg = "Error:ALTER COLUMN will make an index too large\n";
                    strErrorMsg = strErrorMsg + "Cause: Increasing the length of a column would cause the combined length of the columns specified in a previous CREATE INDEX statement to exceed the maximum index length (255). The total index length is computed as the sum of the width of all indexed columns plus the number of indexed columns. Date fields are calculated as a length of 7, character fields are calculated at their defined width, and numeric fields are length 22.\n";
                    strErrorMsg = strErrorMsg + "Action: The only way to alter the column is to drop the affected index. The index cannot be re-created if to do so would exceed the maximum index width";
                    break;
                case 1405:
                    strErrorMsg = "Error:fetched column value is NULL\n";
                    strErrorMsg = strErrorMsg + "Cause: The INTO clause of a FETCH operation contained a NULL value, and no indicator was used. The column buffer in the program remained unchanged, and the cursor return code was +2. This is an error unless you are running Oracle with DBMS=6, emulating version 6, in which case it is only a warning.\n";
                    strErrorMsg = strErrorMsg + "Action: Use the NVL function to convert the retrieved NULL to another value, such as zero or blank. This is the simplest solution";
                    break;
                case 1406:
                    strErrorMsg = "Error:fetched column value was truncated\n";
                    strErrorMsg = strErrorMsg + "Cause: In a host language program, a FETCH operation was forced to truncate a character string. The program buffer area for this column was not large enough to contain the entire string. The cursor return code from the fetch was +3.\n";
                    strErrorMsg = strErrorMsg + "Action: Increase the column buffer area to hold the largest column value or perform other appropriate processing";
                    break;
                case 1407:
                    strErrorMsg = "Error:cannot update (string) to NULL\n";
                    strErrorMsg = strErrorMsg + "Cause: An attempt was made to update a table column USER.TABLE.COLUMN with a NULL value.\n";
                    strErrorMsg = strErrorMsg + "Action: Retry the operation with a value other than NULL";
                    break;
                case 1408:
                    strErrorMsg = "Error:such column list already indexed\n";
                    strErrorMsg = strErrorMsg + "Cause: A CREATE INDEX statement specified a column that is already indexed. A single column may be indexed only once. Additional indexes may be created on the column if it is used as a portion of a concatenated index, that is, if the index consists of multiple columns.\n";
                    strErrorMsg = strErrorMsg + "Action: Do not attempt to re-index the column, as it is unnecessary. To create a concatenated key, specify one or more additional columns in the CREATE INDEX statement";
                    break;
                case 1409:
                    strErrorMsg = "Error:NOSORT option may not be used; rows are not in ascending order\n";
                    strErrorMsg = strErrorMsg + "Cause: Creation of index with NOSORT option when rows were not ascending. The NOSORT option may only be used for indexes on groups of rows that already are in ascending order.\n";
                    strErrorMsg = strErrorMsg + "For non-unique indexes the ROWID is considered part of the index key. This means that two rows that appear to be stored in ascending order may not be. If you create an index NOSORT, and two of the rows in the table have the same index values, but get split across two extents, the data block address of the first block in the second extent can be less than the data block address of the last block in the first extent. If these addresses are not in ascending order, the ROWIDs are not either. Since these ROWIDs are considered part of the index key, the index key is not in ascending order, and the create index NOSORT fails.\n";
                    strErrorMsg = strErrorMsg + "Action: Create the index without the NOSORT option or ensure that the table is stored in one extent";
                    break;
                 case 1410:
                    strErrorMsg = "Error:invalid ROWID\n";
                    strErrorMsg = strErrorMsg + "Cause: A ROWID was entered incorrectly. ROWIDs must be entered as formatted hexadecimal strings using only numbers and the characters A through F. A typical ROWID format is '000001F8.0001.0006'.\n";
                    strErrorMsg = strErrorMsg + "Action: Check the format,: enter the ROWID using the correct format. ROWID format: block ID, row in block, file ID";
                    break;
                case 1411:
                    strErrorMsg = "Error:cannot store the length of column in the indicator\n";
                    strErrorMsg = strErrorMsg + "Cause: An attempt was made to fetch a column of size more than 64K and could not store the length of the column in the given indicator of size 2 bytes.\n";
                    strErrorMsg = strErrorMsg + "Action: Use the new bind type with call backs to fetch the long column";
                    break;
                 case 1412:
                    strErrorMsg = "Error:zero length not allowed for this datatype\n";
                    strErrorMsg = strErrorMsg + "Cause: The length for type 97 is 0.\n";
                    strErrorMsg = strErrorMsg + "Action: Specify the correct length";
                    break;
                case 1413:
                    strErrorMsg = "Error:illegal value in packed decimal number buffer\n";
                    strErrorMsg = strErrorMsg + "Cause: The user buffer bound by the user as packed decimal number contained an illegal value.\n";
                    strErrorMsg = strErrorMsg + "Action: Use a legal value";
                    break;
                case 1414:
                    strErrorMsg = "Error:invalid array length when trying to bind array\n";
                    strErrorMsg = strErrorMsg + "Cause: An attempt was made to bind an array without either a current array length pointer or a zero maximum array length.\n";
                    strErrorMsg = strErrorMsg + "Action: Specify a valid length";
                    break;
                case 1415:
                    strErrorMsg = "Error:too many distinct aggregate functions\n";
                    strErrorMsg = strErrorMsg + "Cause: The query contains more distinct aggregates than can be processed. The current limit is 255.\n";
                    strErrorMsg = strErrorMsg + "Action: Reduce the number of distinct aggregate functions in the query";
                    break;
                case 1416:
                    strErrorMsg = "Error:two tables cannot be outer-joined to each other\n";
                    strErrorMsg = strErrorMsg + "Cause: Two tables in a join operation specified an outer join with respect to each other. If an outer join is specified on one of the tables in a join condition, it may not be specified on the other table.\n";
                    strErrorMsg = strErrorMsg + "Action: Remove the outer join specification (+) from one of the tables,: retry the operation";
                    break;
                case 1417:
                    strErrorMsg = "Error:a table may be outer joined to at most one other table\n";
                    strErrorMsg = strErrorMsg + "Cause: a.b (+) = b.b and a.c (+) = c.c is not allowed.\n";
                    strErrorMsg = strErrorMsg + "Action: Check that this is really what you want,: join b and c first in a view";
                    break;
                case 1418:
                    strErrorMsg = "Error:specified index does not exist\n";
                    strErrorMsg = strErrorMsg + "Cause: An ALTER INDEX, DROP INDEX, or VALIDATE INDEX statement specified the name of an index that does not exist. Only existing indexes can be altered, dropped, or validated. Existing indexes may be listed by querying the data dictionary.\n";
                    strErrorMsg = strErrorMsg + "Action: Specify the name of an existing index in the ALTER INDEX, DROP INDEX, or VALIDATE INDEX statement";
                    break;
                case 1419:
                    strErrorMsg = "Error:datdts: illegal format code\n";
                    strErrorMsg = strErrorMsg + "Cause: An attempt was made to use an incorrect format.\n";
                    strErrorMsg = strErrorMsg + "Action: Inspect the format, correct it if necessary,: retry the operation";
                    break;
                case 1420:
                    strErrorMsg = "Error:datstd: illegal format code\n";
                    strErrorMsg = strErrorMsg + "Cause: An attempt was made to use an invalid format.\n";
                    strErrorMsg = strErrorMsg + "Action: Inspect the format, correct it if necessary,: retry the operation";
                    break;
                case 1421:
                    strErrorMsg = "Error: datrnd/dattrn: illegal precision specifier\n";
                    strErrorMsg = strErrorMsg + "Cause: An attempt was made to use an invalid precision specifier.\n";
                    strErrorMsg = strErrorMsg + "Action: Inspect the precision specifier, correct it if necessary,: retry the operation";
                    break;
                case 1422:
                    strErrorMsg = "Error: exact fetch returns more than requested number of rows\n";
                    strErrorMsg = strErrorMsg + "Cause: The number specified in exact fetch is less than the rows returned.\n";
                    strErrorMsg = strErrorMsg + "Action: Rewrite the query or change number of rows requested";
                    break;
                case 1423:
                    strErrorMsg = "Error: error encountered while checking for extra rows in exact fetch\n";
                    strErrorMsg = strErrorMsg + "Cause: An error was encountered during the execution of an exact fetch. This message will be followed by more descriptive messages.\n";
                    strErrorMsg = strErrorMsg + "Action: See the accompanying messages and take appropriate action";
                    break;
                case 1424:
                    strErrorMsg = "Error: missing or illegal character following the escape character\n";
                    strErrorMsg = strErrorMsg + "Cause: The character following the escape character in LIKE pattern is missing or not one of the escape character, '%', or '_'.\n";
                    strErrorMsg = strErrorMsg + "Action: Remove the escape character or specify the missing character";
                    break;
                case 1425:
                    strErrorMsg = "Error:escape character must be character string of length 1\n";
                    strErrorMsg = strErrorMsg + "Cause: Given escape character for LIKE is not a character string of length 1.\n";
                    strErrorMsg = strErrorMsg + "Action: Change it to a character string of length 1";
                    break;
                case 1426:
                    strErrorMsg = "Error:Numeric overflow\n";
                    strErrorMsg = strErrorMsg + "Cause: Evaluation of an value expression causes an overflow/underflow.\n";
                    strErrorMsg = strErrorMsg + "Action: Reduce the operands";
                    break;
                case 1427:
                    strErrorMsg = "Error:single-row subquery returns more than one row\n";
                    strErrorMsg = strErrorMsg + "Cause: The outer query must use one of the keywords ANY, ALL, IN, or NOT IN to specify values to compare because the subquery returned more than one row.\n";
                    strErrorMsg = strErrorMsg + "Action: Use ANY, ALL, IN, or NOT IN to specify which values to compare or reword the query so only one row is retrieved";
                    break;
                case 1428:
                    strErrorMsg = "Error:argument 'string' is out of range\n";
                    strErrorMsg = strErrorMsg + "Cause: An illegal value for a mathematical function argument was specified. For example\n";
                    strErrorMsg = strErrorMsg + "SELECT SQRT(-1) Square Root FROM DUAL;\n";
                    strErrorMsg = strErrorMsg + "Action: See the Oracle8i SQL Reference manual for valid input and ranges of the mathematical functions";
                    break;
                case 1429:
                    strErrorMsg = "Error:Index-Organized Table: no data segment to store overflow row-pieces\n";
                    strErrorMsg = strErrorMsg + "Cause: No overflow segment defined.\n";
                    strErrorMsg = strErrorMsg + "Action: Add overflow segment";
                    break;
                case 1430:
                    strErrorMsg = "Error:column being added already exists in table\n";
                    strErrorMsg = strErrorMsg + "Cause: An ALTER TABLE ADD statement specified the name of a column that is already in the table. All column names must be unique within a table.\n";
                    strErrorMsg = strErrorMsg + "Action: Specify a unique name for the new column,: re-execute the statement";
                    break;
                case 1431:
                    strErrorMsg = "Error:internal inconsistency in GRANT command\n";
                    strErrorMsg = strErrorMsg + "Cause: An internal error occurred while attempting to execute a GRANT statement.\n";
                    strErrorMsg = strErrorMsg + "Action: Contact Oracle Customer Support";
                    break;
                case 1432:
                    strErrorMsg = "Error:public synonym to be dropped does not exist\n";
                    strErrorMsg = strErrorMsg + "Cause: The synonym specified in DROP PUBLIC SYNONYM is not a valid public synonym. It may be a private synonym.\n";
                    strErrorMsg = strErrorMsg + "Action: Correct the synonym name or use DROP SYNONYM if the synonym is not public";
                    break;
                case 1433:
                    strErrorMsg = "Error:synonym to be created is already defined\n";
                    strErrorMsg = strErrorMsg + "Cause: A CREATE SYNONYM statement specified a synonym name that is the same as an existing synonym, table, view, or cluster. Synonyms may not have the same name as any other synonym, table, view, or cluster available to the user creating the synonym";
                    strErrorMsg = strErrorMsg + "Action: Specify a unique name for the synonym,: re-execute the statement";
                    break;
                case 1434:
                    strErrorMsg = "Error:private synonym to be dropped does not exist\n";
                    strErrorMsg = strErrorMsg + "Cause: A DROP SYNONYM statement specified a synonym that does not exist. Existing synonym names may be listed by querying the data dictionary.\n";
                    strErrorMsg = strErrorMsg + "Action: Specify the name of an existing synonym in the DROP SYNONYM statement";
                    break;
                case 1435:
                    strErrorMsg = "Error:user does not exist\n";
                    strErrorMsg = strErrorMsg + "Cause: This message is caused by any reference to a non-existent user. For example, it occurs if a SELECT, GRANT, or REVOKE statement specifies a username that does not exist. Only a GRANT CONNECT statement may specify a new username. All other GRANT and REVOKE statements must specify existing usernames. If specified in a SELECT statement, usernames must already exist.\n";
                    strErrorMsg = strErrorMsg + "Action: Specify only existing usernames in the SELECT, GRANT, or REVOKE statement or ask the database administrator to define the new username";
                    break;
                case 1436:
                    strErrorMsg = "Error:CONNECT BY loop in user data\n";
                    strErrorMsg = strErrorMsg + "Cause: The condition specified in a CONNECT BY clause caused a loop in the query, where the next record to be selected is a descendent of itself. When this happens, there can be no end to the query.\n";
                    strErrorMsg = strErrorMsg + "Action: Check the CONNECT BY clause and remove the circular reference";
                    break;
                case 1437:
                    strErrorMsg = "Error:cannot have join with CONNECT BY\n";
                    strErrorMsg = strErrorMsg + "Cause: A join operation was specified with a CONNECT BY clause. If a CONNECT BY clause is used in a SELECT statement for a tree-structured query, only one table may be referenced in the query.\n";
                    strErrorMsg = strErrorMsg + "Action: Remove either the CONNECT BY clause or the join operation from the SQL statement";
                    break;
                case 1438:
                    strErrorMsg = "Error:value larger than specified precision allows for this column\n";
                    strErrorMsg = strErrorMsg + "Cause: When inserting or updating records, a numeric value was entered that exceeded the precision defined for the column.\n";
                    strErrorMsg = strErrorMsg + "Action: Enter a value that complies with the numeric column's precision, or use the MODIFY option with the ALTER TABLE command to expand the precision";
                    break;
                case 1439:
                    strErrorMsg = "Error:column to be modified must be empty to change datatype\n";
                    strErrorMsg = strErrorMsg + "Cause: An ALTER TABLE MODIFY statement attempted to change the datatype of a column containing data. A column whose datatype is to be altered must contain only NULL values.\n";
                    strErrorMsg = strErrorMsg + "Action: To alter the datatype, first set all values in the column to NULL";
                    break;
                case 1440:
                    strErrorMsg = "Error:column to be modified must be empty to decrease precision or scale\n";
                    strErrorMsg = strErrorMsg + "Cause: An ALTER TABLE MODIFY statement attempted to decrease the scale or precision of a numeric column containing data. In order to decrease either of these values, the column must contain only NULL values. An attempt to increase the scale without also increasing the precision will also cause this message.\n";
                    strErrorMsg = strErrorMsg + "Action: Set all values in the column to NULL before decreasing the numeric precision or scale. If attempting to increase the scale, increase the precision in accordance with the scale or set all values in the column to NULL first";
                    break;
                case 1441:
                    strErrorMsg = "Error:column to be modified must be empty to decrease column length\n";
                    strErrorMsg = strErrorMsg + "Cause: An ALTER TABLE MODIFY statement attempted to decrease the size of a character field containing data. A column whose maximum size is to be decreased must contain only NULL values.\n";
                    strErrorMsg = strErrorMsg + "Action: Set all values in column to NULL before decreasing the maximum size";
                    break;
                case 1442:
                    strErrorMsg = "Error:column to be modified to NOT NULL is already NOT NULL\n";
                    strErrorMsg = strErrorMsg + "Cause: An ALTER TABLE MODIFY statement attempted to change a column specification unnecessarily, from NOT NULL to NOT NULL.\n";
                    strErrorMsg = strErrorMsg + "Action: No action required";
                    break;
                case 1443:
                    strErrorMsg = "Error:internal inconsistency; illegal datatype in resultant view column\n";
                    strErrorMsg = strErrorMsg + "Cause: An internal error occurred in referencing a view.\n";
                    strErrorMsg = strErrorMsg + "Action: Contact Oracle Customer Support";
                    break;
                case 1444:
                    strErrorMsg = "Error:internal inconsistency; internal datatype maps to invalid external type\n";
                    strErrorMsg = strErrorMsg + "Cause: This is an internal error message not normally issued.\n";
                    strErrorMsg = strErrorMsg + "Action: Contact Oracle Customer Support";
                    break;
                case 1445:
                    strErrorMsg = "Error:cannot select ROWID from a join view without a key-preserved table\n";
                    strErrorMsg = strErrorMsg + "Cause: A SELECT statement attempted to select ROWIDs from a view derived from a join operation. Because the rows selected in the view do not correspond to underlying physical records, no ROWIDs can be returned.\n";
                    strErrorMsg = strErrorMsg + "Action: Remove ROWID from the view selection clause,: re-execute the statement";
                    break;
                case 1446:
                    strErrorMsg = "Error:cannot select ROWID from view with DISTINCT, GROUP BY, etc.\n";
                    strErrorMsg = strErrorMsg + "Cause: A SELECT statement attempted to select ROWIDs from a view containing columns derived from functions or expressions. Because the rows selected in the view do not correspond to underlying physical records, no ROWIDs can be returned.\n";
                    strErrorMsg = strErrorMsg + "Action: Remove ROWID from the view selection clause,: re-execute the statement";
                    break;
                case 1447:
                    strErrorMsg = "Error:ALTER TABLE does not operate on clustered columns\n";
                    strErrorMsg = strErrorMsg + "Cause: An ALTER TABLE MODIFY statement specified a column used to cluster the table. Clustered columns may not be altered.\n";
                    strErrorMsg = strErrorMsg + "Action: To alter the column, first re-create the table in non-clustered form. The column's size can be increased at the same time";
                    break;
                case 1448:
                    strErrorMsg = "Error:index must be dropped before changing to desired type\n";
                    strErrorMsg = strErrorMsg + "Cause: An ALTER TABLE MODIFY statement attempted to change an indexed character column to a LONG column. Columns with the datatype LONG may not be indexed, so the index must be dropped before the modification.\n";
                    strErrorMsg = strErrorMsg + "Action: Drop all indexes referencing the column before changing its datatype to LONG";
                    break;
                case 1449:
                    strErrorMsg = "Error:column contains NULL values; cannot alter to NOT NULL\n";
                    strErrorMsg = strErrorMsg + "Cause: An ALTER TABLE MODIFY statement attempted to change the definition of a column containing NULL values to NOT NULL. The column may not currently contain any NULL values if it is to be altered to NOT NULL.\n";
                    strErrorMsg = strErrorMsg + "Action: Set all NULL values in the column to values other than NULL before ALTERING the column to NOT NULL";
                    break;
                case 1450:
                    strErrorMsg = "Error:maximum key length (string) exceeded\n";
                    strErrorMsg = strErrorMsg + "Cause: The combined length of all the columns specified in a CREATE INDEX statement exceeded the maximum index length. The maximum index length varies by operating system. The total index length is computed as the sum of the width of all indexed columns plus the number of indexed columns. Date fields have a length of 7, character fields have their defined length, and numeric fields have a length of 22. Numeric length = (precision/2) + 1. If negative, add +1.\n";
                    strErrorMsg = strErrorMsg + "Action: Select columns to be indexed so the total index length does not exceed the maximum index length for the operating system. See also your operating system-specific Oracle documentation";
                    break;
                case 1451:
                    strErrorMsg = "Error:column to be modified to NULL cannot be modified to NULL\n";
                    strErrorMsg = strErrorMsg + "Cause: The column may already allow NULL values, the NOT NULL constraint is part of a primary key or check constraint, or an ALTER TABLE MODIFY statement attempted to change a column specification unnecessarily, from NULL to NULL.\n";
                    strErrorMsg = strErrorMsg + "Action: If a primary key or check constraint is enforcing the NOT NULL constraint,: drop that constraint";
                    break;
                case 1452:
                    strErrorMsg = "Error:cannot CREATE UNIQUE INDEX; duplicate keys found\n";
                    strErrorMsg = strErrorMsg + "Cause: A CREATE UNIQUE INDEX statement specified one or more columns that currently contain duplicate values. All values in the indexed columns must be unique by row to create a UNIQUE INDEX.\n";
                    strErrorMsg = strErrorMsg + "Action: If the entries need not be unique, remove the keyword UNIQUE from the CREATE INDEX statement,: re-execute the statement. If the entries must be unique, as in a primary key,: remove duplicate values before creating the UNIQUE index";
                    break;
                case 1453:
                    strErrorMsg = "Error:SET TRANSACTION must be first statement of transaction\n";
                    strErrorMsg = strErrorMsg + "Cause: A transaction was not processed properly because the SET TRANSACTION statement was not the first statement.\n";
                    strErrorMsg = strErrorMsg + "Action: Commit or roll back the current transaction before using the statement SET TRANSACTION";
                    break;
                case 1454:
                    strErrorMsg = "Error:cannot convert column into numeric datatype\n";
                    strErrorMsg = strErrorMsg + "Cause: A non-numeric value could not be converted into a number value.\n";
                    strErrorMsg = strErrorMsg + "Action: Check the value to make sure it contains only numbers, a sign, a decimal point, and the character E or e,: retry the operation";
                    break;
                case 1455:
                    strErrorMsg = "Error:converting column overflows integer datatype\n";
                    strErrorMsg = strErrorMsg + "Cause: The converted form of the specified expression was too large for the specified datatype.\n";
                    strErrorMsg = strErrorMsg + "Action: Define a larger datatype or correct the data";
                    break;
                case 1456:
                    strErrorMsg = "Error:may not perform insert/delete/update operation inside a READ ONLY transaction\n";
                    strErrorMsg = strErrorMsg + "Cause: A non-DDL insert/delete/update or select for update operation was attempted.\n";
                    strErrorMsg = strErrorMsg + "Action: Commit (or roll back) the transaction, and: re-execute";
                    break;
                case 1457:
                    strErrorMsg = "Error:converting column overflows decimal datatype\n";
                    strErrorMsg = strErrorMsg + "Cause: The converted form of the specified expression was too large for the specified type. The problem also occurs in COBOL programs when using COMP-3 in the picture clause, which is acceptable to the Pro*COBOL Precompiler and to COBOL but results in this error.\n";
                    strErrorMsg = strErrorMsg + "Action: Define a larger datatype or correct the data";
                    break;
                case 1458:
                    strErrorMsg = "Error:invalid length inside variable character string\n";
                    strErrorMsg = strErrorMsg + "Cause: An attempt was made to bind or define a variable character string with a buffer length less than the minimum requirement.\n";
                    strErrorMsg = strErrorMsg + "Action: Increase the buffer size or use a different type";
                    break;
                case 1459:
                    strErrorMsg = "Error:invalid length for variable character string\n";
                    strErrorMsg = strErrorMsg + "Cause: The buffer length was less than the minimum required or greater than its length at bind time minus two bytes.\n";
                    strErrorMsg = strErrorMsg + "Action: Make sure the string size is long enough to hold the buffer";
                    break;
                case 1460:
                    strErrorMsg = "Error:unimplemented or unreasonable conversion requested\n";
                    strErrorMsg = strErrorMsg + "Cause: The requested format conversion is not supported.\n";
                    strErrorMsg = strErrorMsg + "Action: Remove the requested conversion from the SQL statement. Check the syntax for the TO_CHAR, TO_DATE, and TO_NUMBER functions to see which conversions are supported";
                    break;
                case 1461:
                    strErrorMsg = "Error:can bind a LONG value only for insert into a LONG column\n";
                    strErrorMsg = strErrorMsg + "Cause: An attempt was made to insert a value from a LONG datatype into another datatype. This is not allowed.\n";
                    strErrorMsg = strErrorMsg + "Action: Do not try to insert LONG datatypes into other types of columns";
                    break;
                case 1462:
                    strErrorMsg = "Error:cannot insert string literals longer than 4000 characters\n";
                    strErrorMsg = strErrorMsg + "Cause: The longest literal supported by Oracle consists of 2000 characters.\n";
                    strErrorMsg = strErrorMsg + "Action: Reduce the number of characters in the literal to 2000 characters or fewer or use the VARCHAR2 or LONG datatype to insert strings exceeding 2000 characters";
                    break;
                case 1463:
                    strErrorMsg = "Error:cannot modify column datatype with current constraint(s)\n";
                    strErrorMsg = strErrorMsg + "Cause: An attempt was made to modify the datatype of column which has referential constraints; or has check constraints which only allows changing the datatype from CHAR to VARCHAR or vise versa.\n";
                    strErrorMsg = strErrorMsg + "Action: Remove the constraint(s) or do not perform the offending operation";
                    break;
                case 1464:
                    strErrorMsg = "Error:circular grant (granting to grant ancestor) of table or view\n";
                    strErrorMsg = strErrorMsg + "Cause: The user in the TO clause of the GRANT statement has already been GRANTed privileges on this table.\n";
                    strErrorMsg = strErrorMsg + "Action: Do not GRANT privileges on a table to the user who originally GRANTed privileges on that table. The statement in error is probably unnecessary";
                    break;
                case 1465:
                    strErrorMsg = "Error:invalid hex number\n";
                    strErrorMsg = strErrorMsg + "Cause: In an UPDATE statement following a SELECT FOR UPDATE, part of the ROWID contains invalid characters. ROWID must be expressed in the proper and expected format for ROWID and within quotes.\n";
                    strErrorMsg = strErrorMsg + "Action: Enter the ROWID just as it was returned in the SELECT FOR UPDATE";
                    break;
                case 1466:
                    strErrorMsg = "Error:unable to read data - table definition has changed\n";
                    strErrorMsg = strErrorMsg + "Cause: This is a time-based read consistency error for a database object, such as a table or index. Either of the following may have happened:\n";
                    strErrorMsg = strErrorMsg + "The query was parsed and executed with a snapshot older than the time the object was changed";
                    break;
                case 1467:
                    strErrorMsg = "Error:sort key too long\n";
                    strErrorMsg = strErrorMsg + "Cause: A DISTINCT, GROUP BY, ORDER BY, or SET operation requires a sort key longer than that supported by Oracle. Either too many columns or too many group functions were specified in the SELECT statement.\n";
                    strErrorMsg = strErrorMsg + "Action: Reduce the number of columns or group functions involved in the operation";
                    break;
                case 1468:
                    strErrorMsg = "Error:a predicate may reference only one outer-joined table\n";
                    strErrorMsg = strErrorMsg + "Cause: A predicate in the WHERE clause has two columns from different tables with (+)";
                    strErrorMsg = strErrorMsg + "Action: Change the WHERE clause so that each predicate has a maximum of one outer-join table";
                    break;
                case 1469:
                    strErrorMsg = "Error:PRIOR can only be followed by a column name\n";
                    strErrorMsg = strErrorMsg + "Cause: An invalid column name was specified after the PRIOR keyword.\n";
                    strErrorMsg = strErrorMsg + "Action: Check syntax, spelling, use a valid column name, and try again";
                    break;
                case 1470:
                    strErrorMsg = "Error:In-list iteration does not support mixed operators\n";
                    strErrorMsg = strErrorMsg + "Cause: Constants of different types are specified in an in-list.\n";
                    strErrorMsg = strErrorMsg + "Action: Use constants of same type for in-lists";
                    break;
                case 1471:
                    strErrorMsg = "Error:cannot create a synonym with same name as object\n";
                    strErrorMsg = strErrorMsg + "Cause: An attempt was made to create a private synonym with the same name as the object to which it refers. This error typically occurs when a user attempts to create a private synonym with the same name as one of their objects.\n";
                    strErrorMsg = strErrorMsg + "Action: Choose a different synonym name or create the synonym under a different username";
                    break;
                case 1472:
                    strErrorMsg = "Error:cannot use CONNECT BY on view with DISTINCT, GROUP BY, etc.\n";
                    strErrorMsg = strErrorMsg + "Cause: CONNECT BY cannot be used on a view where there is not a correspondence between output rows and rows of the underlying table.\n";
                    strErrorMsg = strErrorMsg + "Action: Remove the DISTINCT or GROUP BY from the view or move the CONNECT BY clause into the view";
                    break;
                case 1473:
                    strErrorMsg = "Error:cannot have subqueries in CONNECT BY clause\n";
                    strErrorMsg = strErrorMsg + "Cause: Subqueries cannot be used in a CONNECT BY clause.\n";
                    strErrorMsg = strErrorMsg + "Action: Remove the subquery or move it to the WHERE clause";
                    break;
                case 1474:
                    strErrorMsg = "Error:cannot have START WITH or PRIOR without CONNECT BY\n";
                    strErrorMsg = strErrorMsg + "Cause: START WITH and PRIOR are meaningful only in connection with CONNECT BY.\n";
                    strErrorMsg = strErrorMsg + "Action: Check the syntax for the SQL statement and add a CONNECT BY clause, if necessary";
                    break;
                case 1475:
                    strErrorMsg = "Error:must reparse cursor to change bind variable datatype\n";
                    strErrorMsg = strErrorMsg + "Cause: After executing a statement, an attempt was made to rebind a bind variable with a datatype different from that of the original bind.\n";
                    strErrorMsg = strErrorMsg + "Action: Re-parse the cursor before rebinding with a different datatype";
                    break;
                case 1476:
                    strErrorMsg = "Error:divisor is equal to zero\n";
                    strErrorMsg = strErrorMsg + "Cause: An expression attempted to divide by zero.\n";
                    strErrorMsg = strErrorMsg + "Action: Correct the expression,: retry the operation";
                    break;
                case 1477:
                    strErrorMsg = "Error:user data area descriptor is too large\n";
                    strErrorMsg = strErrorMsg + "Cause: This is an internal error message not normally issued.\n";
                    strErrorMsg = strErrorMsg + "Action: Contact Oracle Customer Support";
                    break;
                case 1478:
                    strErrorMsg = "Error:array bind may not include any LONG columns\n";
                    strErrorMsg = strErrorMsg + "Cause: User is performing an array bind with a bind variable whose maximum size is greater than 2000 bytes.\n";
                    strErrorMsg = strErrorMsg + "Action: Such bind variables cannot participate in array binds. Use an ordinary bind operation instead";
                    break;
                case 1479:
                    strErrorMsg = "Error:last character in the buffer is not Null\n";
                    strErrorMsg = strErrorMsg + "Cause: A bind variable of type 97 does not contain null at the last position.\n";
                    strErrorMsg = strErrorMsg + "Action: Make the last character null";
                    break;
                case 1480:
                    strErrorMsg = "Error:trailing null missing from STR bind value\n";
                    strErrorMsg = strErrorMsg + "Cause: A bind variable of type 5 (null-terminated string) does not contain the terminating null in its buffer.\n";
                    strErrorMsg = strErrorMsg + "Action: Terminate the string with a null character";
                    break;
                case 1481:
                    strErrorMsg = "Error:invalid number format model\n";
                    strErrorMsg = strErrorMsg + "Cause: An invalid format parameter was used with the TO_CHAR or TO_NUMBER function.\n";
                    strErrorMsg = strErrorMsg + "Action: Correct the syntax,: retry the operation";
                    break;
                case 1482:
                    strErrorMsg = "Error:unsupported character set\n";
                    strErrorMsg = strErrorMsg + "Cause: The second or third parameter to the CONVERT function is not a supported character set.\n";
                    strErrorMsg = strErrorMsg + "Action: Use one of the supported character sets";
                    break;
                case 1484:
                    strErrorMsg = "Error:arrays can only be bound to PL/SQL statements\n";
                    strErrorMsg = strErrorMsg + "Cause: At attempt was made to bind an array to a non-PL/SQL statement.\n";
                    strErrorMsg = strErrorMsg + "Action: Rewrite the offending code being careful to bind arrays only to PL/SQL statements";
                    break;
                case 1920:
                    strErrorMsg = "Error: User Name Conflicts With Another User Or Role Name\n";
                    strErrorMsg = strErrorMsg + "Cause: This User Already Exist In The Current Oracle Database.\n";
                    strErrorMsg = strErrorMsg + "Action: Create User With Another User Name";
                    break;
                case 2250:
                    strErrorMsg = "Error:missing or invalid constraint name\n";
                    strErrorMsg = strErrorMsg + "Cause: The constraint name is missing or invalid.\n";
                    strErrorMsg = strErrorMsg + "Action: Specify a valid identifier name for the constraint name";
                    break;
                case 2251:
                    strErrorMsg = "Error:subquery not allowed here\n";
                    strErrorMsg = strErrorMsg + "Cause: Subquery is not allowed here in the statement.\n";
                    strErrorMsg = strErrorMsg + "Action: Remove the subquery from the statement";
                    break;
                case 2252:
                    strErrorMsg = "Error:check constraint condition not properly ended\n";
                    strErrorMsg = strErrorMsg + "Cause: The specified search condition for the check constraint is not properly ended.\n";
                    strErrorMsg = strErrorMsg + "Action: End the condition properly";
                    break;
                case 2253:
                    strErrorMsg = "Error:constraint specification not allowed here\n";
                    strErrorMsg = strErrorMsg + "Cause: Constraint specification is not allowed here in the statement.\n";
                    strErrorMsg = strErrorMsg + "Action: Remove the constraint specification from the statement";
                    break;
                case 2277:
                    strErrorMsg = "Error:invalid sequence name\n";
                    strErrorMsg = strErrorMsg + "Cause: The specified sequence name is not a valid identifier name.\n";
                    strErrorMsg = strErrorMsg + "Action: Specify a valid identifier name for the sequence name";
                    break;
                case 2278:
                    strErrorMsg = "Error:duplicate or conflicting MAXVALUE/NOMAXVALUE specifications\n";
                    strErrorMsg = strErrorMsg + "Cause: Duplicate or conflicting MAXVALUE and/or NOMAXVALUE specifications.\n";
                    strErrorMsg = strErrorMsg + "Action: Remove one of the conflicting specifications and try again";
                    break;
                case 2279:
                    strErrorMsg = "Error:duplicate or conflicting MINVALUE/NOMINVALUE specifications\n";
                    strErrorMsg = strErrorMsg + "Cause: Duplicate or conflicting MINVALUE and/or NOMINVALUE clauses were specified.\n";
                    strErrorMsg = strErrorMsg + "Action: Remove one of the conflicting specifications and try again";
                    break;
                case 2280:
                    strErrorMsg = "Error:duplicate or conflicting CYCLE/NOCYCLE specifications\n";
                    strErrorMsg = strErrorMsg + "Cause: Duplicate or conflicting CYCLE and/or NOCYCLE clauses were specified.\n";
                    strErrorMsg = strErrorMsg + "Action: Remove one of the conflicting specifications and try again";
                    break;
                case 2281:
                    strErrorMsg = "Error:duplicate or conflicting CACHE/NOCACHE specifications\n";
                    strErrorMsg = strErrorMsg + "Cause: Duplicate or conflicting CACHE and/or NOCACHE clauses were specified.\n";
                    strErrorMsg = strErrorMsg + "Action: Remove one of the conflicting specifications and try again";
                    break;
                case 2282:
                    strErrorMsg = "Error:duplicate or conflicting ORDER/NOORDER specifications\n";
                    strErrorMsg = strErrorMsg + "Cause: Duplicate or conflicting ORDER and/or NOORDER clauses were specified.\n";
                    strErrorMsg = strErrorMsg + "Action: Remove one of the conflicting specifications and try again";
                    break;
                case 2283:
                    strErrorMsg = "Error:cannot alter starting sequence number\n";
                    strErrorMsg = strErrorMsg + "Cause: An attempt was made to alter a starting sequence number. This is not allowed.\n";
                    strErrorMsg = strErrorMsg + "Action: Do not try to alter a starting sequence number";
                    break;
                case 2284:
                    strErrorMsg = "Error:duplicate INCREMENT BY specifications\n";
                    strErrorMsg = strErrorMsg + "Cause: A duplicate INCREMENT BY clause was specified.\n";
                    strErrorMsg = strErrorMsg + "Action: Remove the duplicate specification and try again.\n";
                    break;
                case 2285:
                    strErrorMsg = "Error:duplicate START WITH specifications\n";
                    strErrorMsg = strErrorMsg + "Cause: A duplicate START WITH clause was specified.\n";
                    strErrorMsg = strErrorMsg + "Action: Remove the duplicate specification and try again";
                    break;
                case 2286:
                    strErrorMsg = "Error:no options specified for ALTER SEQUENCE\n";
                    strErrorMsg = strErrorMsg + "Cause: No ALTER SEQUENCE option was specified.\n";
                    strErrorMsg = strErrorMsg + "Action: Check the syntax.: specify at least one ALTER SEQUENCE option";
                    break;
                case 2287:
                    strErrorMsg = "Error:sequence number not allowed here\n";
                    strErrorMsg = strErrorMsg + "Cause: The specified sequence number reference, CURRVAL or NEXTVAL, is inappropriate at this point in the statement.\n";
                    strErrorMsg = strErrorMsg + "Action: Check the syntax.: remove or relocate the sequence number";
                    break;
                case 2288:
                    strErrorMsg = "Error:invalid OPEN mode\n";
                    strErrorMsg = strErrorMsg + "Cause: A mode other than RESETLOGS was specified in an ALTER DATABASE OPEN statement. RESETLOGS is the only valid OPEN mode.\n";
                    strErrorMsg = strErrorMsg + "Action: Remove the invalid mode from the statement or replace it with the keyword RESETLOGS, and try again";
                    break;
                case 2289:
                    strErrorMsg = "Error:sequence does not exist\n";
                    strErrorMsg = strErrorMsg + "Cause: The specified sequence does not exist, or the user does not have the required privilege to perform this operation.\n";
                    strErrorMsg = strErrorMsg + "Action: Make sure the sequence name is correct, and that you have the right to perform the desired operation on this sequence";
                    break;
                case 2290:
                    strErrorMsg = "Error:check constraint (string.string) violated\n";
                    strErrorMsg = strErrorMsg + "Cause: The value or values attempted to be entered in a field or fields violate a defined check constraint.\n";
                    strErrorMsg = strErrorMsg + "Action: Enter values that satisfy the constraint";
                    break;
                case 2291:
                    strErrorMsg = "Error:integrity constraint (string.string) violated - parent key not found\n";
                    strErrorMsg = strErrorMsg + "Cause: A foreign key value has no matching primary key value.\n";
                    strErrorMsg = strErrorMsg + "Action: Delete the foreign key or add a matching primary key";
                    break;
                case 2292:
                    strErrorMsg = "Error: This Record can't be deleted because related information exists\n";
                    strErrorMsg = strErrorMsg + "Cause: An attempt was made to delete a row that is referenced by a foreign key.\n";
                    strErrorMsg = strErrorMsg + "Action: It is necessary to DELETE or UPDATE the foreign key before changing this row";
                    break;
                default:
                    strErrorMsg = "Error: " + strError + "\n";
                    //strErrorMsg = strErrorMsg + "Cause: An attempt was made to delete a row that is referenced by a foreign key.\n";
                    strErrorMsg = strErrorMsg + "Action: Contact Your Database Administrator";
                    
                    break;

            }
            return strErrorMsg;

        }

    }
}