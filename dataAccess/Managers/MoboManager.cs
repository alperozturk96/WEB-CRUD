using System;
using System.Collections.Generic;
using System.Text;

namespace dataAccess
{
    public class MoboManager
    {
        //private static MoboManager mobomanager;
        private static dbContext _context;
        public MoboManager()
        {
            if (_context == null)
            {
                _context = new dbContext();
            }
        }

        //public MoboManager getInstance()
        //{
        //    if (mobomanager == null)
        //    {
        //        mobomanager = new MoboManager();
        //        return mobomanager;
        //    }
        //    else
        //        return mobomanager;
        //}

        public void setValues()
        {

        }

        public void UpdateFromTable(Entity.Motherboard data )
        {
            string query = ($"UPDATE motherboard SET chipsetname = '{data.chipsetName}',name = '{data.name}',socketName = '{data.socketName}' WHERE moboId = {data.moboId}");
            _context.UpdateCommand(query);
        }
        
        public void InsertIntoTable(Entity.Motherboard data)
        {
            //chipsetname,name,socketname

            _context.InsertCommand($"INSERT INTO motherboard (chipsetName,name,socketName) VALUES ('{ data.chipsetName}','{ data.name}','{data.socketName}')");
        }
        public List<Entity.Motherboard> SelectTable()
        {
            string query = "SELECT * FROM motherboard";
           
            var result = new List<Entity.Motherboard>();
            var datas = _context.SelectCommandList(query);

            for (int i = 0; i < datas.Rows.Count; i++) // fill edilmiş datatable üzerindeki satırları tek tek dolanıyor.
            {
                result.Add(new Entity.Motherboard
                {
                    moboId = Convert.ToInt32(datas.Rows[i]["moboId"]),
                    pcPartID = datas.Rows[i]["pcPartID"] == DBNull.Value ? 0 : Convert.ToInt32(datas.Rows[i]["pcPartID"]),
                    name = datas.Rows[i]["name"].ToString(),
                    chipsetName = Convert.ToString(datas.Rows[i]["chipsetName"]),
                    socketName = datas.Rows[i]["socketName"].ToString()
                });
            }

            return result;
        }
        public void DeleteTableData(byte id)
        {
            string query = $"DELETE FROM motherboard WHERE moboId = {id}";

            _context.DeleteCommand(query);
        }
    }
}
