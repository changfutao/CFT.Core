using CFT.Core.Common.BaseModel;
using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFT.Core.Model.Admin
{
    /// <summary>
    /// 角色
    /// </summary>
    [Table(Name ="ad_role")]
    [Index("idx_{tablename}_01", nameof(Name),isUnique: true)]
    public class RoleEntity : EntityFull
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Description("名称")]
        [Column(StringLength = 50)]
        public string Name { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        [Description("说明")]
        [Column(StringLength = 200)]
        public string Description { get; set; }
        /// <summary>
        /// 启用
        /// </summary>
        [Description("启用")]
        public bool Enabled { get; set; } = true;
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
    }
}
