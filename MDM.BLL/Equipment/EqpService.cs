using MDM.DAL.Equipment;
using MDM.Model.UserEntities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MDM.BLL.Equipment
{
    public interface IEqpService
    {
        List<Eqp> GetAllEqps();
        List<Eqp> GetEqpList(string eqpType, string eqpGroupId);
        List<Eqp> GetSubEqps(string parentEqpId);
        List<Port> GetPorts(string eqpId);
        List<string> GetAllEqpGroupIds();
        List<string> GetAllEqpTypes();
        List<EqpGroup> GetAllEqpGroups();

        // 添加设备
        bool AddEqp(Eqp eqp);

        // 更新设备
        bool UpdateEqp(Eqp eqp);

        // 删除设备
        bool DeleteEqp(string eqpId);

        // 添加端口
        bool AddPort(Port port);

        // 更新端口
        bool UpdatePort(Port port);

        // 删除端口
        bool DeletePort(string portId);
    }

    public class EqpService : IEqpService
    {
        private readonly EqpRepository _repository;

        public EqpService(EqpRepository repository)
        {
            _repository = repository;
            Debug.WriteLine("EqpService 已初始化");
        }

        public List<Eqp> GetAllEqps()
        {
            try
            {
                var eqps = _repository.GetAllEqps();
                Debug.WriteLine($"EqpService.GetAllEqps: 获取到 {eqps.Count} 条记录");
                return eqps;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EqpService.GetAllEqps 发生异常: {ex.Message}");
                return new List<Eqp>();
            }
        }

        public List<Eqp> GetEqpList(string eqpType, string eqpGroupId)
        {
            try
            {
                var eqps = _repository.GetEqpList(eqpType, eqpGroupId);
                Debug.WriteLine($"EqpService.GetEqpList: 获取到 {eqps.Count} 条记录");
                return eqps;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EqpService.GetEqpList 发生异常: {ex.Message}");
                return new List<Eqp>();
            }
        }


        public List<Eqp> GetSubEqps(string parentEqpId)
        {
            try
            {
                return _repository.GetSubEqps(parentEqpId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EqpService.GetSubEqps 发生异常: {ex.Message}");
                return new List<Eqp>();
            }
        }

        public List<Port> GetPorts(string eqpId)
        {
            try
            {
                return _repository.GetPorts(eqpId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EqpService.GetPorts 发生异常: {ex.Message}");
                return new List<Port>();
            }
        }

        public List<string> GetAllEqpGroupIds()
        {
            try
            {
                return _repository.GetAllEqpGroupIds();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EqpService.GetAllEqpGroupIds 发生异常: {ex.Message}");
                return new List<string>();
            }
        }

        public List<string> GetAllEqpTypes()
        {
            try
            {
                return _repository.GetAllEqpTypes();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EqpService.GetAllEqpTypes 发生异常: {ex.Message}");
                return new List<string>();
            }
        }

        public List<EqpGroup> GetAllEqpGroups()
        {
            try
            {
                var eqpGroups = _repository.GetAllEqpGroups();
                Debug.WriteLine($"EqpService.GetAllEqpGroups: 获取到 {eqpGroups.Count} 条记录");
                return eqpGroups;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EqpService.GetAllEqpGroups 发生异常: {ex.Message}");
                return new List<EqpGroup>();
            }
        }

        public bool AddEqp(Eqp eqp)
        {
            try
            {
                return _repository.AddEqp(eqp);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EqpService.AddEqp 发生异常: {ex.Message}");
                return false;
            }
        }

        public bool UpdateEqp(Eqp eqp)
        {
            try
            {
                return _repository.UpdateEqp(eqp);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EqpService.UpdateEqp 发生异常: {ex.Message}");
                return false;
            }
        }

        public bool DeleteEqp(string eqpId)
        {
            try
            {
                return _repository.DeleteEqp(eqpId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EqpService.DeleteEqp 发生异常: {ex.Message}");
                return false;
            }
        }

        public bool AddPort(Port port)
        {
            try
            {
                return _repository.AddPort(port);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EqpService.AddPort 发生异常: {ex.Message}");
                return false;
            }
        }

        public bool UpdatePort(Port port)
        {
            try
            {
                return _repository.UpdatePort(port);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EqpService.UpdatePort 发生异常: {ex.Message}");
                return false;
            }
        }

        public bool DeletePort(string portId)
        {
            try
            {
                return _repository.DeletePort(portId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EqpService.DeletePort 发生异常: {ex.Message}");
                return false;
            }
        }
    }
}
