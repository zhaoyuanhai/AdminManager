namespace AdminModels.Customs
{
    public class ConditionModel
    {
        public string Field { get; set; }

        public Operation Op { get; set; }

        public string Value { get; set; }
    }

    public enum Operation
    {
        /// <summary>
        /// 等于
        /// </summary>
        equal,

        /// <summary>
        /// 不等于
        /// </summary>
        notequal,

        /// <summary>
        /// 大于
        /// </summary>
        greaterthan,

        /// <summary>
        /// 小于
        /// </summary>
        lessthan,

        /// <summary>
        /// 大于等于
        /// </summary>
        gtequal,

        /// <summary>
        /// 小于等于
        /// </summary>
        ltequal,

        /// <summary>
        /// 在一个范围之间
        /// </summary>
        between,

        /// <summary>
        /// 包含
        /// </summary>
        contain
    }
}