[1mdiff --git a/Src/OpenCBS.Engine/AdjustmentPolicy/LastInstallmentAdjustmentPolicy.cs b/Src/OpenCBS.Engine/AdjustmentPolicy/LastInstallmentAdjustmentPolicy.cs[m
[1mindex d49ad60..95a7420 100644[m
[1m--- a/Src/OpenCBS.Engine/AdjustmentPolicy/LastInstallmentAdjustmentPolicy.cs[m
[1m+++ b/Src/OpenCBS.Engine/AdjustmentPolicy/LastInstallmentAdjustmentPolicy.cs[m
[36m@@ -1,6 +1,7 @@[m
 ﻿using System.Collections.Generic;[m
 using System.ComponentModel.Composition;[m
 using OpenCBS.CoreDomain.Contracts.Loans.Installments;[m
[32m+[m[32musing OpenCBS.Engine.InstallmentCalculationPolicy;[m
 using OpenCBS.Engine.Interfaces;[m
 [m
 namespace OpenCBS.Engine.AdjustmentPolicy[m
[36m@@ -12,6 +13,11 @@[m [mnamespace OpenCBS.Engine.AdjustmentPolicy[m
         public void Adjust(List<Installment> schedule, IScheduleConfiguration configuration)[m
         {[m
             schedule[schedule.Count - 1].CapitalRepayment += GetAdjustment(schedule, configuration);[m
[32m+[m[32m            if (configuration.CalculationPolicy.GetType() == typeof(FlatInstallmentCalculationPolicy))[m
[32m+[m[32m            {[m
[32m+[m[32m                schedule[schedule.Count - 1].InterestsRepayment += GetAdjustmentInterestRepayment(schedule,[m
[32m+[m[32m                    configuration);[m
[32m+[m[32m            }[m
         }[m
     }[m
 }[m
