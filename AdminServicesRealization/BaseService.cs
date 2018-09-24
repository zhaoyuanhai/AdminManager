using System;
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
using AdminModels.Customs;

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

        public virtual int Add(T model)
        {
            if (model == null)
                throw new ArgumentException("model参数不能为null");

            entities.Set<T>().Add(model);
            return entities.SaveChanges();
        }

        public virtual int AddBatch(IEnumerable<T> models)
        {
            if (models == null)
                throw new ArgumentException("models参数不能为null");

            entities.Set<T>().AddRange(models);
            return entities.SaveChanges();
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

            model._UpdateDate = DateTime.Now;
            entities.Entry(model).Property(x => x._CreateDate).IsModified = false;

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

        public virtual T Find(params object[] keyValues)
        {
            return entities.Set<T>().Find(keyValues);
        }

        public virtual IEnumerable<T> Select()
        {
            return entities.Set<T>().ToList();
        }

        public virtual IEnumerable<T> Select(Expression<Func<T, bool>> expression)
        {
            return entities.Set<T>().Where(expression).ToList();
        }

        public virtual IPageingModel<T> SelectPage(int pageIndex, int pageSize)
        {
            return SelectPage(x => true, pageIndex, pageSize);
        }

        public virtual IPageingModel<T> SelectPage(Expression<Func<T, bool>> expression, int pageIndex, int pageSize)
        {
            var total = entities.Set<T>().Count();
            var datas = entities.Set<T>().WhereIf(expression, expression != null).OrderBy(x => x.Id).Skip((pageIndex - 1) * pageIndex).Take(pageSize).ToList();
            return new PageingModel<T>(pageIndex, pageSize, total, datas);
        }

        public IPageingModel<T> SelectPage(IExpressionLambdaModel conditions, int pageIndex, int pageSize)
        {
            var expression = conditions?.ToExpression<T>();
            return this.SelectPage(expression, pageIndex, pageSize);
        }

        public virtual int Delete(int id)
        {
            var entity = entities.Set<T>().First(x => x.Id == id);
            entities.Set<T>().Remove(entity);
            return entities.SaveChanges();
        }

        public virtual int DeleteBatch(IEnumerable<int> ids)
        {
            var datas = from entity in entities.Set<T>()
                        join id in ids on entity.Id equals id
                        select entity;
            entities.Set<T>().RemoveRange(datas);
            return entities.SaveChanges();
        }

        public virtual T First(Expression<Func<T, bool>> expression)
        {
            return entities.Set<T>().First(expression);
        }

        public virtual T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return entities.Set<T>().FirstOrDefault(expression);
        }
    }
}
