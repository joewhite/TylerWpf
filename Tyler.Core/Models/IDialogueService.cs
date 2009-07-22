using System.Windows.Documents;

namespace Tyler.Models
{
    public interface IDialogueService
    {
        void Show(FlowDocument dialogue);
    }
}