using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AdminModels
{
    public class ModelBase
    {
        [HiddenInput(DisplayValue = false)]
        public virtual int Id { get; set; }

        [Display(Name = "添加时间"), ReadOnly(true)]
        public virtual DateTime _CreateDate { get; set; } = DateTime.Now;

        [Display(Name = "修改时间"), ReadOnly(true)]
        public virtual DateTime? _UpdateDate { get; set; }
    }
}