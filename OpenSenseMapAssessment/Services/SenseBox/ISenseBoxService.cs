using OpenSenseMapAssessment.Models.SenseBox;

namespace OpenSenseMapAssessment.Services.SenseBox
{
    public interface ISenseBoxService
    {
        Task<SenseBoxResponse> CreateNewSenseBoxAsync(SenseBoxRequest request);
        Task<SenseBoxData> GetSenseBoxByIdAsync(string senseBoxId);
    }
}
