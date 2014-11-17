﻿﻿﻿﻿﻿﻿using System.Collections.Generic;
﻿﻿﻿﻿﻿﻿using System.Linq;
﻿﻿﻿﻿﻿﻿﻿using System.Windows.Forms;
﻿﻿﻿﻿﻿﻿﻿using OpenCBS.ArchitectureV2.Interface.Presenter;
using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.ArchitectureV2.Interface.View;
using OpenCBS.CoreDomain;
using OpenCBS.CoreDomain.Contracts.Loans;
using OpenCBS.CoreDomain.Contracts.Savings;
using OpenCBS.Services;
using OpenCBS.Shared.Settings;

namespace OpenCBS.ArchitectureV2.Presenter
{
    public class RepaymentPresenter : IRepaymentPresenter, IRepaymentPresenterCallbacks
    {
        private Loan _loan;
        private ISavingsContract _saving;
        private readonly IRepaymentView _view;
        private readonly IRepaymentService _repaymentService;
        private readonly ITranslationService _translationService;
        private string _balanceString;

        public RepaymentPresenter(IRepaymentView view, IRepaymentService repaymentService, ITranslationService translationService)
        {
            _view = view;
            _repaymentService = repaymentService;
            _translationService = translationService;
        }

        public void Setup()
        {
            _repaymentService.Settings.Loan = _loan.Copy();
            _view.PrincipalMax = _loan.OLB;
            _view.PaymentMethods = ServicesProvider.GetInstance().GetPaymentMethodServices().GetAllPaymentMethods();
            _view.PaymentTypes = new Dictionary<int, string>
                {
                    {0, _translationService.Translate("Normal")},
                    {1, _translationService.Translate("Early")}
                };
            _view.Title = _loan.Project.Client.Name + " " + _loan.Code;
            _balanceString = _translationService.Translate("Available balance: ");
            if(ApplicationSettings.GetInstance(User.CurrentUser.Md5).ShowExtraInterestColumn)
                _view.ShowExtraColumn();
            if (!ApplicationSettings.GetInstance(User.CurrentUser.Md5).UseMandatorySavingAccount) return;
            _saving =
                (from item in _loan.Project.Client.Savings where item.LoanId == _loan.Id select item)
                    .FirstOrDefault();
            if (_saving != null)
                _saving = ServicesProvider.GetInstance().GetSavingServices().GetSaving(_saving.Id);
        }

        public object View { get { return _view; } }

        public DialogResult Run(Loan loan)
        {
            _loan = loan;
            Setup();
            OnRefresh();
            _view.Attach(this);
            OnRefresh();
            _view.Run();
            return _view.DialogResult;
        }

        public void OnRepay()
        {
            _view.DialogResult = DialogResult.OK;
            _loan = ServicesProvider.GetInstance()
                                    .GetContractServices()
                                    .SaveInstallmentsAndRepaymentEvents(_loan,
                                                                        _repaymentService.Settings.Loan.InstallmentList,
                                                                        _repaymentService.Settings.Loan.Events);
            _view.Stop();
        }

        public void OnRefresh()
        {
            if (_repaymentService.Settings.Principal == _view.Principal &&
                _repaymentService.Settings.Interest == _view.Interest &&
                _repaymentService.Settings.Penalty == _view.Penalty &&
                _repaymentService.Settings.Comment == _view.Comment &&
                _repaymentService.Settings.Date.Date == _view.Date.Date &&
                _repaymentService.Settings.Amount == _view.Amount &&
                _repaymentService.Settings.BounceFee == _view.BounceFee &&
                _repaymentService.Settings.PaymentTypeId == _view.SelectedPaymentTypeId) return;
            if (_repaymentService.Settings.Date.Date != _view.Date.Date)
            {
                _repaymentService.Settings.DateChanged = true;
                _repaymentService.Settings.Date = _view.Date;
                if (_saving != null)
                    _view.Description = _balanceString + _saving.GetBalance(_view.Date).Value.ToString("N2");
            }
            if (_repaymentService.Settings.Amount != _view.Amount ||
                _repaymentService.Settings.PaymentTypeId != _view.SelectedPaymentTypeId)
            {
                _repaymentService.Settings.AmountChanged = true;
                _repaymentService.Settings.Amount = _view.Amount;
            }
            _repaymentService.Settings.Loan = _loan.Copy();
            _repaymentService.Settings.Comment = _view.Comment;
            _repaymentService.Settings.BounceFee = _view.BounceFee;
            _repaymentService.Settings.Interest = _view.Interest;
            _repaymentService.Settings.Penalty = _view.Penalty;
            _repaymentService.Settings.Principal = _view.Principal;
            _repaymentService.Settings.PaymentMethod = _view.SelectedPaymentMethod;
            _repaymentService.Settings.PaymentTypeId = _view.SelectedPaymentTypeId;
            _repaymentService.Repay();
            _repaymentService.Settings.DateChanged = false;
            _repaymentService.Settings.AmountChanged = false;
            _repaymentService.Settings.Amount = _repaymentService.Settings.BounceFee +
                                                _repaymentService.Settings.Interest +
                                                _repaymentService.Settings.Penalty +
                                                _repaymentService.Settings.Principal;
            if (_saving != null)
                _view.OkButtonEnabled = _repaymentService.Settings.Amount <= _saving.GetBalance(_view.Date).Value;
            else _view.OkButtonEnabled = _repaymentService.Settings.Amount > 0;
            RefreshAmounts();
        }

        public void OnCancel()
        {
            _view.DialogResult = DialogResult.Cancel;
            _view.Stop();
        }

        private void RefreshAmounts()
        {
            _view.Loan = _repaymentService.Settings.Loan;
            _view.BounceFee = _repaymentService.Settings.BounceFee;
            _view.Interest = _repaymentService.Settings.Interest;
            _view.Penalty = _repaymentService.Settings.Penalty;
            _view.Principal = _repaymentService.Settings.Principal;
            _view.Amount = _repaymentService.Settings.Amount;
            _view.Loan = _repaymentService.Settings.Loan;
        }
    }
}
