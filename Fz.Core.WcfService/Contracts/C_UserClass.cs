using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Fz.Core.WcfService
{
    /// <summary>
    /// 用户所属年级班级列表
    /// </summary>
    [DataContract]
    public class C_UserClass
    {
        /// <summary>
        /// 年级Id
        /// </summary>
        [DataMember]
        public int GradeId { get; set; }

        /// <summary>
        /// 年级名称
        /// </summary>
        [DataMember]
        public string GradeName { get; set; }

        /// <summary>
        /// 班级Id
        /// </summary>
        [DataMember]
        public int ClassId { get; set; }

        /// <summary>
        /// 班级名称
        /// </summary>
        [DataMember]
        public string ClassName { get; set; }
    }
}