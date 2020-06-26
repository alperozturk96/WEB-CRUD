using dataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dataAccess
{
    public  class CpuManager
    {
        private static dbContext _context;
        //private static CpuManager cpumanager;
        public CpuManager()
        {
            if (_context==null)
            {
                _context = new dbContext();
            }
        }

        // public CpuManager getInstance()
        //{
        //    if (cpumanager == null)
        //    {
        //        cpumanager = new CpuManager();
        //    }
        //    return cpumanager;
        //}


        public void UpdateFromTable(Cpu data)
        {
            string query = ($"UPDATE processors SET name = '{data.Name}',cachesize = '{data.cachesize}',nanometer = '{data.nanometer}',speed = {data.speed} WHERE cpuid = {data.cpuid}");
            _context.UpdateCommand(query);
        }

        public void InsertIntoTable(Cpu data)
        {
            //name,cachesize,nanometer,speed
            _context.InsertCommand($"INSERT INTO processors (name,cachesize,nanometer,speed) VALUES ('{data.Name}',{data.cachesize},{data.nanometer},{data.speed})");
        }
        public List<Cpu> SelectTable()
        {
           string query = "SELECT * FROM processors";

           var result = new List<Cpu>();
           var datas= _context.SelectCommandList(query);

            for (int i = 0; i < datas.Rows.Count; i++) // fill edilmiş datatable üzerindeki satırları tek tek dolanıyor.
            {
                result.Add(new Cpu
                {
                    cpuid =Convert.ToInt32(datas.Rows[i]["cpuid"]),
                    cachesize = Convert.ToInt32(datas.Rows[i]["cachesize"]),
                    Name = datas.Rows[i]["name"].ToString(),
                    nanometer = Convert.ToInt32(datas.Rows[i]["nanometer"]),
                    pcPartID = datas.Rows[i]["pcPartID"]== DBNull.Value ? 0: Convert.ToInt32(datas.Rows[i]["pcPartID"]),
                    speed = Convert.ToInt32(datas.Rows[i]["speed"])
                });
            }

            return result;
        }
        public void DeleteTableData(byte id)
        {
            string query = $"DELETE FROM processors WHERE cpuid = {id}";

            _context.DeleteCommand(query);
        }

    }
}
