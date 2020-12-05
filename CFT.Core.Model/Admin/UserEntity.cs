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
    /// 用户
    /// </summary>
    [Table(Name ="ad_user")]
    [Index("idx_{tablename}_01", nameof(UserName),isUnique: true)]
    public class UserEntity : EntityFull
    {
        /// <summary>
        /// 账号
        /// </summary>
        [Description("账号")]
        [Column(StringLength = 60)]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Description("密码")]
        [Column(StringLength = 60)]
        public string Password { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [Description("昵称")]
        [Column(StringLength = 60)]
        public string NickName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        [Description("头像")]
        [Column(StringLength = 100)]
        public string Avatar { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Description("状态")]
        public int Status { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        [Column(StringLength = 500)]
        public string Remark { get; set; }
    }
}
