export class Vacancy {
    id: string;
    title: string;
    workingCondition: WorkingCondition;
    description: string;
    city: string;
    isRemoteWorking: boolean;
    organizationName: string;
    email: string;
    companyURL: string;
    phoneNumber: string;
    contactPartner: string;
    salary: number;
    currencyType: CurrencyType;
    date: Date;
}

enum CurrencyType {
    EUR,
    RUB,
    USD
}

enum WorkingCondition {
    Contract,
    Freelance,
    FullTime,
    PartTime
}
