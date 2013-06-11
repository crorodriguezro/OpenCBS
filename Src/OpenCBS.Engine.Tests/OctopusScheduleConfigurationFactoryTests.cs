using System;
using NUnit.Framework;
using OpenCBS.CoreDomain.Contracts.Loans;
using OpenCBS.CoreDomain.Products;
using OpenCBS.Engine.InstallmentCalculationPolicy;
using OpenCBS.Enums;
using OpenCBS.Shared;

namespace OpenCBS.Engine.Test
{
    [TestFixture]
    public class OctopusScheduleConfigurationFactoryTests
    {
        private OctopusScheduleConfigurationFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new OctopusScheduleConfigurationFactory(NonWorkingDateSingleton.GetInstance(string.Empty));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Loan cannot be null.")]
        public void GetConfiguration_NoLoan_ThrowsException()
        {
            _factory.Init().WithLoan(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Loan product cannot be null.")]
        public void GetConfiguration_NoLoanProduct_ThrowsException()
        {
            var loan = new Loan();
            _factory.Init().WithLoan(loan);
        }

        [Test]
        public void GetConfiguration_LoanType_CalculationPolicyIsProperlySet()
        {
            var loanProduct = new LoanProduct { LoanType = OLoanTypes.Flat };
            var loan = new Loan
            {
                Product = loanProduct,
            };
            var configuration = _factory.Init().WithLoan(loan).GetConfiguration();
            Assert.That(configuration.CalculationPolicy, Is.InstanceOf<FlatInstallmentCalculationPolicy>());
            
            loanProduct.LoanType = OLoanTypes.DecliningFixedInstallments;
            configuration = _factory.Init().WithLoan(loan).GetConfiguration();
            Assert.That(configuration.CalculationPolicy, Is.InstanceOf<AnnuityInstallmentCalculationPolicy>());

            loanProduct.LoanType = OLoanTypes.DecliningFixedPrincipal;
            configuration = _factory.Init().WithLoan(loan).GetConfiguration();
            Assert.That(configuration.CalculationPolicy, Is.InstanceOf<FixedPrincipalInstallmentCalculationPolicy>());
        }
    }
}
