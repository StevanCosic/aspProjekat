using ProjekatiApplication.commands;
using ProjekatiApplication.DataTransfer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ProjekatImplementation.commands
{
    public class RawSQLCreateCommand : IcreateGroupeCommand  
    {

        private readonly IDbConnection dbConnection;
            public RawSQLCreateCommand(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public int id => 2;

        public string name => "Create Group Using Raw SQL";

        public void Execute(GroupeDto request)
        {
            var query = "INSERT INTO GROUPE (name) VALUES ('" + request.name + "')";
            var command = dbConnection.CreateCommand();
            command.CommandText = query;
            command.ExecuteNonQuery();
                
        }
    }
}
