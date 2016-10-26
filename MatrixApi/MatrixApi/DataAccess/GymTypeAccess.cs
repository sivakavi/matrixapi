using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using MatrixApi.Models;
using MatrixApi.Core;

namespace MatrixApi.DataAccess
{
    public class GymTypeAccess
    {
        public List<Dictionary<string, object>> GetAllGymType()
        {
            return DbAccess.DbASelect("SELECT * FROM tbl_gymtype");
        }

        public List<Dictionary<string, object>> GetGymTypeById(int gymtypeid)
        {
            return DbAccess.DbASelect("SELECT * FROM tbl_gymtype WHERE gymtypeid='" + gymtypeid + "'");
        }

        public string AddGymType(GymType objGymType)
        {
            return DbAccess.DbAInsert("insert into tbl_gymtype VALUES ('NULL','" + objGymType.gymtypename
                    + "', '" + objGymType.createdat
                    + "', '" + objGymType.updatedat
                    + "')");
        }

        public string EditGymType(GymType objGymType)
        {
            return DbAccess.DbAInsert("UPDATE tbl_gymtype SET "
            + "gymtypename='" + objGymType.gymtypename + "',"
            + "updatedat='" + objGymType.updatedat + "' WHERE gymtypeid='" + objGymType.gymtypeid + "'");
        }
    }
}