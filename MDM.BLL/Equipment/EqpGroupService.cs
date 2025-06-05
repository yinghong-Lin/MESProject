using MDM.DAL.Equipment;
using MDM.Model.UserEntities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MDM.BLL.Equipment
{ 
    public interface IEqpGroupService
    {
        List<EqpGroup> GetAllEqpGroups();
        EqpGroup GetEqpGroupById(string id);
        bool CreateEqpGroup(EqpGroup group);
        bool UpdateEqpGroup(EqpGroup group);
        bool DeleteEqpGroup(string id);
        List<EqpGroupHis> GetEqpGroupHistory(string eqpGroupId);
    }

    public class EqpGroupService : IEqpGroupService
    {
        private readonly EqpGroupRepository _repository;

        public EqpGroupService(EqpGroupRepository repository)
        {
            _repository = repository;
        }

        public List<EqpGroup> GetAllEqpGroups()
        {
            try
            {
                var groups = _repository.GetAllEqpGroups();
                Debug.WriteLine($"EqpGroupService.GetAllEqpGroups: 获取到 {groups.Count} 条记录");
                return groups;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EqpGroupService.GetAllEqpGroups 发生异常: {ex.Message}");
                return new List<EqpGroup>(); // 返回空列表而不是null
            }
        }

        public EqpGroup GetEqpGroupById(string id)
        {
            try
            {
                return _repository.GetEqpGroupById(id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EqpGroupService.GetEqpGroupById 发生异常: {ex.Message}");
                return null;
            }
        }

        public bool CreateEqpGroup(EqpGroup group)
        {
            try
            {
                return _repository.CreateEqpGroup(group);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EqpGroupService.CreateEqpGroup 发生异常: {ex.Message}");
                return false;
            }
        }

        public bool UpdateEqpGroup(EqpGroup group)
        {
            try
            {
                return _repository.UpdateEqpGroup(group);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EqpGroupService.UpdateEqpGroup 发生异常: {ex.Message}");
                return false;
            }
        }

        public bool DeleteEqpGroup(string id)
        {
            try
            {
                return _repository.DeleteEqpGroup(id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EqpGroupService.DeleteEqpGroup 发生异常: {ex.Message}");
                return false;
            }
        }

        public List<EqpGroupHis> GetEqpGroupHistory(string eqpGroupId)
        {
            try
            {
                return _repository.GetEqpGroupHistory(eqpGroupId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EqpGroupService.GetEqpGroupHistory 发生异常: {ex.Message}");
                return new List<EqpGroupHis>();
            }
        }
    }
}
