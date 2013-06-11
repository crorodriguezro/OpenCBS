Feature: FLAT

Scenario: Flat schedule
    Given this configuration
        | Name                 | Value            |
        | Type                 | Flat             |
        | Payments             | Monthly (30 day) |
        | Year                 | 360              |
        | Rounding             | Whole            |
        | Adjustment           | Last installment |
        | Date shift           | Forward          |
        | Installments         | 5                |
        | Grace period         | 0                |
        | Amount               | 5000             |
        | Interest rate        | 24               |
        | Start on             | 01.01.2013       |
        | First repayment on   | 01.02.2013       |
    When I create a schedule
    Then the schedule is
        | Number | Start date | End date   | Repayment date | Principal | Interest | Olb  |
        | 1      | 01.01.2013 | 01.02.2013 | 01.02.2013     | 1000      | 100      | 5000 |
        | 2      | 01.02.2013 | 01.03.2013 | 01.03.2013     | 1000      | 100      | 4000 |
        | 3      | 01.03.2013 | 01.04.2013 | 01.04.2013     | 1000      | 100      | 3000 |
        | 4      | 01.04.2013 | 01.05.2013 | 01.05.2013     | 1000      | 100      | 2000 |
        | 5      | 01.05.2013 | 01.06.2013 | 03.06.2013     | 1000      | 100      | 1000 |
