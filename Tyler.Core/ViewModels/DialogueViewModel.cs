using System.ComponentModel;
using System.Windows;
using System.Windows.Documents;
using Tyler.Models;

namespace Tyler.ViewModels
{
    public class DialogueViewModel : IDialogueService, INotifyPropertyChanged
    {
        private FlowDocument m_document;
        private Visibility m_visibility = Visibility.Collapsed;

        public FlowDocument Document
        {
            get { return m_document; }
            private set
            {
                if (m_document == value)
                    return;
                m_document = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Document"));
            }
        }
        public Visibility Visibility
        {
            get { return m_visibility; }
            set
            {
                if (m_visibility == value)
                    return;
                m_visibility = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Visibility"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Show(FlowDocument dialogue)
        {
            Document = dialogue;
            Visibility = Visibility.Visible;
        }
    }
}