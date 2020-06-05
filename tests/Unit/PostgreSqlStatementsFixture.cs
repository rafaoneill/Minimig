using System;
using Minimig;
using Xunit;

namespace MinimigTests.Unit
{
    public class PostgreSqlStatementsFixture
    {
        [Fact]
        public void PostgreSql_statements_insert()
        {
            //Arrange
            string table = "mymigration";
            const string expected = "INSERT";

            //Act
            var s = new PostgreSqlStatements(table);

            //Assert
            Assert.Contains(expected, s.InsertMigration, StringComparison.InvariantCultureIgnoreCase);
            Assert.Contains(table, s.InsertMigration);
        }

        [Fact]
        public void PostgreSql_statements_insert_with_schema()
        {
            //Arrange
            string table = "mymigration";
            string schema = "tst";
            const string expected = "INSERT";

            //Act
            var s = new PostgreSqlStatements(table, schema);

            //Assert
            Assert.Contains(expected, s.InsertMigration, StringComparison.InvariantCultureIgnoreCase);
            Assert.Contains(table, s.InsertMigration);
            Assert.Contains(schema, s.InsertMigration);
        }

        [Fact]
        public void PostgreSql_statements_update()
        {
            //Arrange
            string table = "mymigration";
            const string expected = "UPDATE";

            //Act
            var s = new PostgreSqlStatements(table);

            //Assert
            Assert.Contains(expected, s.UpdateMigrationHash, StringComparison.InvariantCultureIgnoreCase);
            Assert.Contains(table, s.UpdateMigrationHash);
            Assert.Contains(expected, s.RenameMigration, StringComparison.InvariantCultureIgnoreCase);
            Assert.Contains(table, s.RenameMigration);
        }

        [Fact]
        public void PostgreSql_statements_update_with_schema()
        {
            //Arrange
            string table = "mymigration";
            string schema = "tst";
            const string expected = "UPDATE";

            //Act
            var s = new PostgreSqlStatements(table, schema);

            //Assert
            Assert.Contains(expected, s.UpdateMigrationHash, StringComparison.InvariantCultureIgnoreCase);
            Assert.Contains(table, s.UpdateMigrationHash);
            Assert.Contains(schema, s.UpdateMigrationHash);
            Assert.Contains(expected, s.RenameMigration, StringComparison.InvariantCultureIgnoreCase);
            Assert.Contains(table, s.RenameMigration);
            Assert.Contains(schema, s.RenameMigration);
        }

        [Fact]
        public void PostgreSql_statements_migration_exists()
        {
            //Arrange
            string table = "mymigration";
            const string expected = "SELECT";

            //Act
            var s = new PostgreSqlStatements(table);

            //Assert
            Assert.Contains(expected, s.DoesMigrationsTableExist, StringComparison.InvariantCultureIgnoreCase);
            Assert.Contains(table, s.DoesMigrationsTableExist);
            Assert.Contains(expected, s.GetAlreadyRan, StringComparison.InvariantCultureIgnoreCase);
            Assert.Contains(table, s.GetAlreadyRan);
        }

        [Fact]
        public void PostgreSql_statements__migration_exists_with_schema()
        {
            //Arrange
            string table = "mymigration";
            string schema = "tst";
            const string expected = "SELECT";

            //Act
            var s = new PostgreSqlStatements(table, schema);

            //Assert
            Assert.Contains(expected, s.DoesMigrationsTableExist, StringComparison.InvariantCultureIgnoreCase);
            Assert.Contains(table, s.DoesMigrationsTableExist);
            Assert.Contains(schema, s.DoesMigrationsTableExist);
            Assert.Contains(expected, s.GetAlreadyRan, StringComparison.InvariantCultureIgnoreCase);
            Assert.Contains(table, s.GetAlreadyRan);
            Assert.Contains(schema, s.GetAlreadyRan);
        }

        [Fact]
        public void PostgreSql_statements_create_migration()
        {
            //Arrange
            string table = "mymigration";
            const string expected = "CREATE";

            //Act
            var s = new PostgreSqlStatements(table);

            //Assert
            Assert.Contains(expected, s.CreateMigrationsTable, StringComparison.InvariantCultureIgnoreCase);
            Assert.Contains(table, s.CreateMigrationsTable);
        }

        [Fact]
        public void PostgreSql_statements_create_migration_with_schema()
        {
            //Arrange
            string table = "mymigration";
            string schema = "tst";
            const string expected = "CREATE";

            //Act
            var s = new PostgreSqlStatements(table, schema);

            //Assert
            Assert.Contains(expected, s.CreateMigrationsTable, StringComparison.InvariantCultureIgnoreCase);
            Assert.Contains(table, s.CreateMigrationsTable);
            Assert.Contains(schema, s.CreateMigrationsTable);
        }

        [Fact]
        public void PostgreSql_statements_drop_migration()
        {
            //Arrange
            string table = "mymigration";
            const string expected = "DROP";

            //Act
            var s = new PostgreSqlStatements(table);

            //Assert
            Assert.Contains(expected, s.DropMigrationsTable, StringComparison.InvariantCultureIgnoreCase);
            Assert.Contains(table, s.DropMigrationsTable);
        }

        [Fact]
        public void PostgreSql_statements_drop_migration_with_schema()
        {
            //Arrange
            string table = "mymigration";
            string schema = "tst";
            const string expected = "DROP";

            //Act
            var s = new PostgreSqlStatements(table, schema);

            //Assert
            Assert.Contains(expected, s.DropMigrationsTable, StringComparison.InvariantCultureIgnoreCase);
            Assert.Contains(table, s.DropMigrationsTable);
            Assert.Contains(schema, s.DropMigrationsTable);
        }

        [Fact]
        public void PostgreSql_statements_sql_server_command_splitter()
        {
            //Arrange
            string value = "GO";
            string lowerValue = "go";
            string table = "mymigration";
            string schema = "tst";

            //Act
            var s = new PostgreSqlStatements(table, schema);

            //Assert
            Assert.False(s.CommandSplitter.Match(value).Success);
            Assert.False(s.CommandSplitter.Match(lowerValue).Success);
        }
    }
}