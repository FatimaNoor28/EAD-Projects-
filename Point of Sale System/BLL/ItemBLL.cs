using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class ItemBLL
    {
        public int NewId()
        {
            ItemDAL dal = new ItemDAL();
            int? id = dal.retrieveLastId();
            if (id == null)
                return 1;
            else
                return (int)(id + 1);
        }

        public bool AddItem(ItemDTO dto)
        {
            ItemDAL dal = new ItemDAL();
            bool check = dal.AddItem(dto);
            return check;
        }

        public ItemDTO FindItem(int id)
        {
            ItemDAL dal = new ItemDAL();
            ItemDTO dto = dal.FindItem(id);
            return dto;
        }

        public void ModifyItem(ItemDTO dto)
        {
            ItemDAL da = new ItemDAL();
            da.ModifyItem(dto);
        }

        public void FindItem(ItemDTO dto)
        {
            ItemDAL dal = new ItemDAL();
            dal.FindItem(dto);

        }

        public void RemoveItem(int id)
        {
            ItemDAL dal = new ItemDAL();
            dal.RemoveItem(id);
        }
    }
}
