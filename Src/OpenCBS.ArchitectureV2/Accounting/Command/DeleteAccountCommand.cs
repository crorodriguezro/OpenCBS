using System.Windows.Forms;
using OpenCBS.ArchitectureV2.Interface;
using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.Extension.Accounting.CommandData;
using OpenCBS.Extension.Accounting.Interface.Repository;
using OpenCBS.Extension.Accounting.Message;

namespace OpenCBS.Extension.Accounting.Command
{
    public class DeleteAccountCommand : ArchitectureV2.Command.Command, ICommand<DeleteAccountCommandData>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITranslationService _translationService;
        private readonly IApplicationController _applicationController;

        public DeleteAccountCommand(
            IAccountRepository accountRepository,
            ITranslationService translationService,
            IApplicationController applicationController)
            : base(applicationController)
        {
            _accountRepository = accountRepository;
            _translationService = translationService;
            _applicationController = applicationController;
        }

        public void Execute(DeleteAccountCommandData commandData)
        {
            var message = _translationService.Translate("Are you sure you want to permanently delete this account?");
            var title = _translationService.Translate("Delete Account");
            var result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;
            _accountRepository.Delete(commandData.Account);
            _applicationController.Publish(new AccountSavedMessage(this, null));
        }
    }
}
