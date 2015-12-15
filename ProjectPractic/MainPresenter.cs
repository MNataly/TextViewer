using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextView.BL;

namespace ProjectPractic
{
    class MainPresenter
    {
        private readonly IMainForm _mainForm;
        private readonly IFileManager _manager;
        private readonly IMessageService _messageService;
        private string _curenrFilePath;

        public MainPresenter(IMainForm mainForm, IFileManager fileManager, IMessageService messageService)
        {
            _mainForm = mainForm;
            _manager = fileManager;
            _messageService = messageService;

            _mainForm.FileOpenClick += new EventHandler(_viewFileOpenClick);
            _mainForm.SaveClick += new EventHandler(_viewSaveClick);
        }

        private void _viewSaveClick(object sender, EventArgs e)
        {
            try
            {
                
                string text = _mainForm.text;
            
                
                _manager.SaveText(_curenrFilePath, text);
                _messageService.ShowMessage("File is save!");
            }
            catch (Exception ex)
            {
                
                _messageService.ShowError(ex.Message);
            }
        }

        private void _viewFileOpenClick(object sender, EventArgs eventArgs)
        {
            try
            {
                string filePath = _mainForm.filePath;

                bool isExist = _manager.IsExist(filePath);
                if (!isExist)
                {
                    _messageService.ShowExclamation("File is not found!");
                    return;
                }

                _curenrFilePath = filePath;
                string text = _manager.GetText(filePath);

                _mainForm.text = text;

            }
            catch (Exception ex)
            {
                
                _messageService.ShowError(ex.Message);
            }
        }

    }
}
