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
    public class MemberTypeAccess
    {
        public List<Dictionary<string, object>> GetAllMemberType()
        {
            return DbAccess.DbASelect("SELECT * FROM tbl_membertype");
        }

        public List<Dictionary<string, object>> GetMemberTypeById(int membertypeid)
        {
            return DbAccess.DbASelect("SELECT * FROM tbl_membertype WHERE membertypeid='" + membertypeid + "'");
        }

        public string AddMemberType(MemberType objMemberType)
        {
            return DbAccess.DbAInsert("insert into tbl_membertype VALUES ('NULL','" + objMemberType.membertypename
                    + "', '" + objMemberType.amount
                    + "', '" + objMemberType.duration
                    + "', '" + objMemberType.createdat
                    + "', '" + objMemberType.updatedat
                    + "')");
        }

        public string EditMemberType(MemberType objMemberType)
        {
            return DbAccess.DbAInsert("UPDATE tbl_membertype SET "
            + "membertypename='" + objMemberType.membertypename + "',"
            + "amount='" + objMemberType.amount + "',"
            + "duration='" + objMemberType.duration + "',"
            + "updatedat='" + objMemberType.updatedat + "' WHERE membertypeid='" + objMemberType.membertypeid + "'");
        }
    }
}