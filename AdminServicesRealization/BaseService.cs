﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AdminServices;
using AdminDataEntity;
using AdminCommon;
using AdminModels;
using System.Data.Entity;

namespace AdminServicesRealization
{
    public abstract class BaseService<T> : ISelectService<T>, IModifyService<T>, IDeleteService<T>, IAddService<T> where T : ModelBase, new()
    {
        protected DataEntities entities { get; set; }

        public BaseService()
        {
            this.entities = new DataEntities();
        }

        ~BaseService()
        {
            entities.Dispose();
        }

        public virtual void Add(T model)
        {
            if (model == null)
                throw new ArgumentException("model参数不能为null");

            entities.Set<T>().Add(model);
            entities.SaveChanges();
        }

        public virtual void AddBatch(IEnumerable<T> models)
        {
            if (models == null)
                throw new ArgumentException("models参数不能为null");

            entities.Set<T>().AddRange(models);
            entities.SaveChanges();
        }

        public virtual int Delete(T model)
        {
            if (model == null)
                throw new Exception("model参数不能为null");

            entities.Set<T>().Remove(model);
            return entities.SaveChanges();
        }

        public virtual int DeleteBatch(IEnumerable<T> models)
        {
            entities.Set<T>().RemoveRange(models);
            return entities.SaveChanges();
        }

        public virtual int Modify(T model)
        {
            if (entities.Entry(model).State == EntityState.Detached)
                entities.Entry(model).State = EntityState.Modified;

            return entities.SaveChanges();
        }

        public virtual int ModifyBatch(IEnumerable<T> models)
        {
            foreach (var item in models)
            {
                if (entities.Entry(item).State == EntityState.Modified)
                    entities.Entry(item).State = EntityState.Modified;
            }
            return entities.SaveChanges();
        }

        public virtual IEnumerable<T> Select()
        {
            return entities.Set<T>().ToList();
        }

        public virtual IEnumerable<T> Select(Expression<Func<T, bool>> expression)
        {
            return entities.Set<T>().Where(expression).ToList();
        }

        public virtual Tuple<IEnumerable<T>, int> SelectPage(int pageIndex, int pageSize)
        {
            return SelectPage(x => true, pageIndex, pageSize);
        }

        public virtual Tuple<IEnumerable<T>, int> SelectPage(Expression<Func<T, bool>> expression, int pageIndex, int pageSize)
        {
            var total = entities.Set<T>().Count();
            var datas = entities.Set<T>().Where(expression).Skip((pageIndex - 1) * pageIndex).Take(pageSize).ToList().AsEnumerable();
            return Tuple.Create(datas, total);
        }

        public int Delete(int id)
        {
            var entity = entities.Set<T>().First(x => x.Id == id);
            entities.Set<T>().Remove(entity);
            return entities.SaveChanges();
        }

        public int DeleteBatch(IEnumerable<int> ids)
        {
            var datas = from entity in entities.Set<T>()
                        join id in ids on entity.Id equals id
                        select entity;
            entities.Set<T>().RemoveRange(datas);
            return entities.SaveChanges();
        }
    }
}