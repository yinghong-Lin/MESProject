using MDM.DAL.Process;
using System;
using System.Data;

namespace MDM.BLL.Process
{
    public class ReworkService
    {
        private readonly ReworkRepository _reworkRepository;

        public ReworkService(ReworkRepository reworkRepository)
        {
            _reworkRepository = reworkRepository;
        }

        public DataTable GetBatchFlowDataByBatchId(string batchId)
        {
            return _reworkRepository.GetBatchFlowDataByBatchId(batchId);
        }

        public DataTable GetReworkFlowOptions()
        {
            return _reworkRepository.GetReworkFlowOptions();
        }

        public DataTable GetReworkProcessOptions()
        {
            return _reworkRepository.GetReworkProcessOptions();
        }

        public DataTable GetReturnStationOptions()
        {
            return _reworkRepository.GetReturnStationOptions();
        }

        public DataTable GetReasonCodeOptions()
        {
            return _reworkRepository.GetReasonCodeOptions();
        }

        public bool UpdateBatchReworkInfo(string batchId, string reworkFlowId, string reworkFlowVersion,
            string reworkProcessId, string reworkProcessVersion, string returnStationId, string returnStationVersion,
            string reasonCode, string remark)
        {
            return _reworkRepository.UpdateBatchReworkInfo(batchId, reworkFlowId, reworkFlowVersion,
                reworkProcessId, reworkProcessVersion, returnStationId, returnStationVersion,
                reasonCode, remark);
        }
    }
}
