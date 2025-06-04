using MDM.DAL.Process;
using MDM.Model.UserEntities;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MDM.BLL.Process
{
    public interface IProcessService
    {
        List<Prp> GetAllPrps(string factoryId = null);
        List<Flow> GetAllFlows(string factoryId = null);
        List<Flow> GetFlowsByPrpId(int prpId);
        List<Oper> GetOpersByFlowId(int flowId);
        List<Oper> GetNonOperListByFId(string flowId);
        List<ProductGroup> GetAllProductGroups(string factoryId = null);
        List<Product> GetAllProducts(string factoryId = null, string productGroupId = null);
    }

    public class ProcessService : IProcessService
    {
        private readonly ProcessRepository _repository;

        public ProcessService(ProcessRepository repository)
        {
            _repository = repository;
            Debug.WriteLine("ProcessService 已初始化");
        }

        public List<Flow> GetAllFlows(string factoryId = null)
        {
            try
            {
                var flows = _repository.GetAllFlows(factoryId);
                Debug.WriteLine($"ProcessService.GetAllFlows: 获取到 {flows.Count} 条记录");
                return flows;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ProcessService.GetAllFlows 发生异常: {ex.Message}");
                return new List<Flow>();
            }
        }

        public List<Prp> GetAllPrps(string factoryId = null)
        {
            try
            {
                var prps = _repository.GetAllPrps(factoryId);
                Debug.WriteLine($"ProcessService.GetAllPrps: 获取到 {prps.Count} 条记录");
                return prps;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ProcessService.GetAllPrps 发生异常: {ex.Message}");
                return new List<Prp>();
            }
        }

        public List<Flow> GetFlowsByPrpId(int prpId)
        {
            try
            {
                var flows = _repository.GetFlowsByPrpId(prpId);
                Debug.WriteLine($"ProcessService.GetFlowsByPrpId: 获取到 {flows.Count} 条记录");
                return flows;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ProcessService.GetFlowsByPrpId 发生异常: {ex.Message}");
                return new List<Flow>();
            }
        }

        public List<Oper> GetOpersByFlowId(int flowId)
        {
            try
            {
                var opers = _repository.GetOpersByFlowId(flowId);
                Debug.WriteLine($"ProcessService.GetOpersByFlowId: 获取到 {opers.Count} 条记录");
                return opers;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ProcessService.GetOpersByFlowId 发生异常: {ex.Message}");
                return new List<Oper>();
            }
        }

        public List<Oper> GetNonOperListByFId(string flowId)
        {
            try
            {
                var opers = _repository.GetNonOperListByFId(flowId);
                Debug.WriteLine($"ProcessService.GetNonOperListByFId: 获取到 {opers.Count} 条记录");
                return opers;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ProcessService.GetNonOperListByFId 发生异常: {ex.Message}");
                return new List<Oper>();
            }
        }

        public List<ProductGroup> GetAllProductGroups(string factoryId = null)
        {
            try
            {
                var groups = _repository.GetAllProductGroups(factoryId);
                Debug.WriteLine($"ProcessService.GetAllProductGroups: 获取到 {groups.Count} 条记录");
                return groups;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ProcessService.GetAllProductGroups 发生异常: {ex.Message}");
                return new List<ProductGroup>();
            }
        }

        public List<Product> GetAllProducts(string factoryId = null, string productGroupId = null)
        {
            try
            {
                var products = _repository.GetAllProducts(factoryId, productGroupId);
                Debug.WriteLine($"ProcessService.GetAllProducts: 获取到 {products.Count} 条记录");
                return products;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ProcessService.GetAllProducts 发生异常: {ex.Message}");
                return new List<Product>();
            }
        }
    }
}
