using Fz.Common;
using Fz.Core.WcfService.Contracts;
using System.Collections.Generic;
using System.ServiceModel;

namespace Fz.Core.WcfService
{
    /// <summary>
    /// 基础平台服务
    /// </summary>
    [ServiceContract]
    public interface IBasicService
    {
        /// <summary>
        /// 验证帐号密码是否正确
        /// </summary>
        /// <param name="account">帐号</param>
        /// <param name="password">密码</param>
        /// <returns>返回：【1】成功，【-1】帐号不存在，【-2】密码错误，【-3】帐号已停用</returns>
        [OperationContract]
        int CheckLogin(string account, string password);

        /// <summary>
        /// 根据帐号获取用户信息
        /// </summary>
        /// <param name="account">帐号</param>
        /// <returns></returns>
        [OperationContract]
        C_UserInfo GetUserInfo(string account);

        /// <summary>
        /// 根据凭证获取帐号
        /// </summary>
        /// <param name="ticket">凭证</param>
        /// <param name="ip">IP地址</param>
        /// <returns>凭证无效返回null</returns>
        [OperationContract]
        string GetAccount(string ticket, string ip);

        /// <summary>
        /// 获取全部用户与学科
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        Dictionary<string, string> GetUserAndSubjectDict();

        /// <summary>
        /// 获取学科列表
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        Dictionary<int, string> GetSubjectDict();

        /// <summary>
        /// 获取年级列表
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        Dictionary<int, string> GetGradeDict();

        /// <summary>
        /// 根据版本获取年级列表
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        Dictionary<int, string> GetGradeDictByEdition(int edition);
        /// <summary>
        /// 根据版序列本获取年级列表
        /// </summary>
        /// <param name="editions"></param>
        /// <returns></returns>
        [OperationContract]
        Dictionary<int, string> GetGradeDictByEditions(string editions);
        /// <summary>
        /// 根据年级获取班级列表
        /// </summary>
        /// <param name="grade">年级</param>
        /// <returns></returns>
        [OperationContract]
        Dictionary<int, string> GetClassDict(int grade);

        /// <summary>
        /// 根据班级ID获取学生
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        [OperationContract]
        Dictionary<string, string> GetStudentByClassId(int classId);

        /// <summary>
        /// 获取教材
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        C_Textbook GetTextbookById(int id);

        /// <summary>
        /// 获取教材
        /// </summary>
        /// <param name="Stage">所属学段</param>
        /// <param name="Subject">所属学科</param>
        /// <param name="Grade">所属年级</param>
        /// <param name="Booklet">册别</param>
        /// <param name="Edition">版本</param>
        /// <returns></returns>
        [OperationContract]
        List<C_Textbook> GetTextbookDict(int? Stage, int? Subject, int? Grade, int? Booklet, int? Edition);

        /// <summary>
        /// 根据教材获取目录
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [OperationContract]
        List<C_TextbookCatalog> GetTextbookCatalogDict(int bookId);

        /// <summary>
        /// 根据教材目录获取页码
        /// </summary>
        /// <param name="CatalogId"></param>
        /// <returns></returns>
        [OperationContract]
        int[] GetTextbookPageDict(int CatalogId);

        /// <summary>
        /// 保存教材资源
        /// </summary>
        /// <param name="bookId">教材id</param>
        /// <param name="page">页码</param>
        /// <param name="content">内容</param>
        [OperationContract]
        void SaveTextbookResource(int bookId, int page, string content);

        /// <summary>
        /// 获取教材资源（水滴）
        /// </summary>
        /// <param name="bookId">教材id</param>
        /// <param name="pages">页码（多个）</param>
        /// <returns></returns>
        [OperationContract]
        string[] GetTextbookResource(int bookId, int[] pages);

        /// <summary>
        /// 获取教材版本
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        Dictionary<int, string> GetEditionDict();

        /// <summary>
        /// 根据学科获取教材版本
        /// </summary>
        /// <param name="subject">学科</param>
        /// <returns></returns>
        [OperationContract]
        Dictionary<int, string> GetEditionDictBySubject(int subject);

        /// <summary>
        /// 根据上级节点Id获取资源类型
        /// </summary>
        /// <param name="pid">上级节点Id</param>
        /// <returns></returns>
        [OperationContract]
        Dictionary<int, string> GetResourceType(int pid);

        /// <summary>
        /// 根据教材id更新教材配置文件与教材封面
        /// </summary>
        /// <param name="id">教材id</param>
        /// <param name="stage">教材所属学段</param>
        /// <param name="subject">教材所属学科</param>
        /// <param name="grade">教材所属年级</param>
        /// <param name="booklet">教材所属册别</param>
        /// <param name="edition">教材所属版本</param>
        /// <param name="bookName">教材名称</param>
        /// <param name="config">教材db.js路径</param>
        /// <param name="cover">教材封面路径</param>
        /// <param name="remark">备注</param>
        [OperationContract]
        void UpdateTextbook(int id, int stage, int subject, int grade, int booklet, int edition, string bookName, string config, string cover, string remark);
        /// <summary>
        /// 获取资源列表根据资源Id序列
        /// </summary>
        /// <param name="CatalogIds"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [OperationContract]
        List<R_Resource> GetResourceByCatalogIds(string CatalogIds, int? type = null);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">搜索</param>
        /// <param name="SubjectID">学科</param>
        /// <returns></returns>
        [OperationContract]
        List<R_Resource> GetResourceByKey(string key, int SubjectID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="CatalogIds"></param>
        /// <returns></returns>
        [OperationContract]
        List<R_Resource> GetResourceByUserID(string UserID, string CatalogIds);
        /// <summary>
        /// 移除资源
        /// </summary>
        /// <param name="ResourceIDs"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        [OperationContract]
        bool RemoveResourceByResourceIDs(string ResourceIDs, string UserID);
        /// <summary>
        /// 导入mod资源
        /// </summary>
        /// <param name="files"></param>
        /// <param name="resources"></param>
        /// <returns></returns>
        [OperationContract]
        string ImportModResource(string files, string resources);
    }
}
