Feature: AnnuitySample

Scenario: AnnuitySample
    Given this configuration
        | Name               | Value            |
        | Type               | Annuity          |
        | Payments           | Monthly (30 day) |
        | Year               | 360              |
        | Rounding           | Two decimal      |
        | Adjustment         | Last installment |
        | Date shift         | Backward         |
        | Installments       | 4                |
        | Grace period       | 0                |
        | Amount             | 10000            |
        | Interest rate      | 9,96             |
        | Start on           | 11.05.2010       |
        | First repayment on | 11.06.2010       |
    When I create a schedule
    Then the schedule is
        | Number | Start date | End date   | Repayment date | Principal | Interest | Olb  |
        | 1      | 11.05.2010 | 11.06.2010 | 11.06.2010     | 2469,09   | 83,00    | 10000,00 |
        | 2      | 11.06.2010 | 11.07.2010 | 09.07.2010     | 2489,58   | 62,51    | 7530,91  |
        | 3      | 11.07.2010 | 11.08.2010 | 11.08.2010     | 2510,25   | 41,84    | 5041,33  |
        | 4      | 11.08.2010 | 11.09.2010 | 10.09.2010     | 2531,08   | 21,01    | 2531,08  |
