using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vape.DAL.Entities;
using Vape.DAL.Interfaces;
using VapeApp.DAL.EF;
using VapeApp.DAL.Entities;

namespace Vape.DAL.Repositories
{
    public class OrderRepository :  IRepository<Order>
    {
        private VapeContext db;

        public OrderRepository(VapeContext context)
        {
            this.db = context;
        }

        public IEnumerable<Order> Find(Func<Order, Boolean> predicate)
        {
            return db.Orders.Include(o => o.FullVape).Where(predicate).ToList();
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders.Include(o => o.FullVape);
        }

        public IEnumerable<Order> FindBoxMod(Func<Order, Boolean> predicate)
        {
            return db.Orders.Include(o => o.BoxMod).Where(predicate).ToList();
        }

        public IEnumerable<Order> GetAllBoxMod()
        {
            return db.Orders.Include(o => o.BoxMod);
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        public void Create(Order order)
        {
            db.Orders.Add(order);
        }

        public void Update(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
        }


        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
                db.Orders.Remove(order);
        }

        #region

        public IEnumerable<Order> GetImage(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

}
