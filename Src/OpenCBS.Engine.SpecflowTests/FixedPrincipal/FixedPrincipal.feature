Feature: FIXED_PRINCIPAL

Scenario: FIXED_PRINCIPAL
    Given this configuration
        | Name                 | Value            |
        | Type                 | Fixed principal  |
        | Payments             | Monthly (30 day) |
        | Year                 | 360              |
        | Rounding             | Whole            |
        | Adjustment           | Last installment |
        | Date shift           | Forward          |
        | Installments         | 6                |
        | Grace period         | 0                |
        | Amount               | 5000             |
        | Interest rate        | 20               |
        | Start on             | 01.01.2013       |
        | First repayment on   | 01.02.2013       |
    When I create a schedule
    Then the schedule is
        # Interest is calculated as OLB * 20/100 * 30/360
        | Number | Start date | End date   | Repayment date | Principal | Interest | Olb  |
        | 1      | 01.01.2013 | 01.02.2013 | 01.02.2013     | 833       | 83       | 5000 |
        | 2      | 01.02.2013 | 01.03.2013 | 01.03.2013     | 833       | 69       | 4167 |
        | 3      | 01.03.2013 | 01.04.2013 | 01.04.2013     | 833       | 56       | 3334 |
        | 4      | 01.04.2013 | 01.05.2013 | 01.05.2013     | 833       | 42       | 2501 |
        | 5      | 01.05.2013 | 01.06.2013 | 03.06.2013     | 833       | 28       | 1668 |
        | 6      | 01.06.2013 | 01.07.2013 | 01.07.2013     | 835       | 14       | 835  |
