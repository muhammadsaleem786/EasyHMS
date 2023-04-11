﻿export class ipd_admission {
    ID: number;
    AdmissionNo: string;
    PatientId: number;
    AdmissionTypeId: number;
    AdmissionTypeDropdownId: number;
    DoctorId: number;
    AdmissionDate: Date;
    AdmissionTime: string;
    Location: string;
    ReasonForVisit: string;
    PatientName: string;
    Mobile: string;
    CNIC: string;
    TypeId: number;
    WardTypeId: number;
    WardTypeDropdownId: number;
    BedId: number;
    BedDropdownId: number;
    RoomId: number;
    RoomDropdownId: number;
}
export class ipd_admission_discharge {
    Id: number;
    AdmissionId: number;
    PatientId: number;
    Weight: string;
    Temperature: string;
    DiagnosisAdmission: string;
    ComplaintSummary: string;
    ConditionAdmission: string;
    GeneralCondition: string;
    RespiratoryRate: string;
    BP: string;
    Other: string;
    Systemic: string;
    PA: string;
    PV: string;
    UrineProteins: string;
    Sugar: string;
    Microscopy: string;
    BloodHB: string;
    TLC: string;
    P: string;
    L: string;
    E: string;
    ESR: string;
    BloodSugar: string;
    BloodGroup: string;
    Ultrasound: string;
    UltrasoundRemark: string;
    XRay: string;
    XRayRemark: string;
    Conservative: string;
    Operation: string;
    Date: string;
    Surgeon: string;
    Assistant: string;
    Anaesthesia: string;
    Incision: string;
    OperativeFinding: string;
    OprationNotes: string;
    OPMedicines: string;
    OPProgress: string;
    ConditionDischarge: string;
    RemovalDate: string;
    ConditionWound: string;
    AdviseMedicine: string;
    FollowUpDate: Date;
    OtherRemarks: string;
    CheckedBy: string;
}

export class ipd_admission_charges {
    ID: number;
    AdmissionId: number;
    AppointmentId: number;
    PatientId: number;
    AnnualPE: number;
    General: number;
    Medical: number;
    ICUCharges: number;
    ExamRoom: number;
    PrivateWard: number;
    RIP: number;
    OtherAllCharges: number;
}
export class ipd_admission_imaging {
    ID: number;
    AdmissionId: number;
    AppointmentId: number;
    PatientId: number;
    ImagingTypeId: number;
    ImagingTypeDropdownId: number;
    Notes: string;
    StatusId: number;
    ResultId: number;
    Image: string;
}
export class ipd_admission_lab {
    ID: number;
    CompanyId: number;
    AdmissionId: number;
    AppointmentId: number;
    PatientId: number;
    LabTypeId: number;
    LabTypeDropdownId: number;
    Notes: string;
    CollectDate: Date;
    TestDate: Date;
    ReportDate: Date;
    OrderingPhysician: string;
    Parameter: string;
    ResultValues: string;
    ABN: string;
    Flags: string;
    Comment: string;
    TestPerformedAt: string;
    TestDescription: string;
    StatusId: number;
    ResultId: number;

}
export class ipd_admission_medication {
    ID: number;
    AdmissionId: number;
    AppointmentId: number;
    PatientId: number;
    MedicineId: number;
    Prescription: string;
    PrescriptionDate: Date;
    AppointmentDate: Date;
    QuantityRequested: number;
    Refills: string;
    IsRequestNow: boolean = false;
    BillTo: string;
    MedicineName: string;
}
export class ipd_admission_notes {
    ID: number;
    AdmissionId: number;
    AppointmentId: number;
    PatientId: number;
    OnBehalfOf: string;
    Note: string;
}
export class ipd_admission_vital {
    ID: number;
    AdmissionId: number;
    AppointmentId: number;
    PatientId: number;
    DateRecorded: Date;
    Temperature: number;
    Weight: number;
    Height: number;
    SBP: string;
    DBP: string;
    HeartRate: string;
    RespiratoryRate: string;
}
export class ipd_procedure_charged {
    ID: number;
    AppointmentId: number;
    PatientId: number;
    ProcedureId: number;
    Date: Date;
    Item: string;
    Quantity: number;
}
export class ipd_procedure_medication {
    ID: number;
    AppointmentId: number;
    PatientId: number;
    ProcedureId: number;
    MedicineId: number;
    Quantity: number;
    MedicineName: string;
}
export class ipd_procedure_mf {
    constructor() {
        let objipd_procedure_charged = new ipd_procedure_charged();
        this.ipd_procedure_charged.push(objipd_procedure_charged);
        let objipd_procedure_medication = new ipd_procedure_medication();
        this.ipd_procedure_medication.push(objipd_procedure_medication);
    }
    ID: number;
    CompanyId: number;
    AdmissionId: number;
    AppointmentId: number;
    PatientId: number;
    PatientProcedure: string;
    Date: Date;
    Time: string;
    CPTCodeId: number;
    CPTCodeDropdownId: number;
    Location: string;
    Physician: string;
    Assistant: string;
    Notes: string;
    ipd_procedure_charged: Array<ipd_procedure_charged> = [];
    ipd_procedure_medication: Array<ipd_procedure_medication> = [];
}

export class emr_patient {

    ID: number;
    PatientName: string;
    Gender: number;
    DOB: Date;
    Age: number;
    Email: string;
    Mobile: string;
    ContactNo: string;
    CNIC: string;
    Image: string;
    Notes: string;
    MRNO: string;
    BloodGroupId: number;
    BloodGroupDropDownId: number;
    EmergencyNo: string;
    Address: string;
    ReferredBy: string;
    AnniversaryDate: Date;
    Illness_Diabetes: boolean = false;
    Illness_Tuberculosis: boolean = false;
    Illness_HeartPatient: boolean = false;
    Illness_LungsRelated: boolean = false;
    Illness_BloodPressure: boolean = false;
    Illness_Migraine: boolean = false;
    Illness_Other: string;
    Allergies_Food: string;
    Allergies_Drug: string;
    Allergies_Other: string;
    Habits_Smoking: string;
    Habits_Drinking: string;
    Habits_Tobacco: string;
    Habits_Other: string;
    MedicalHistory: string;
    CurrentMedication: string;
    HabitsHistory: string;
    PrefixTittleId: number;
    PrefixDropdownId: number;
    BillTypeId: number;
    BillTypeDropdownId: number;
    AdmissionNo: number;
}
export class ipd_diagnosis {
    ID: number;
    AdmissionId: number;
    PatientId: number;
    Description: string;
    Date: Date;
    IsType: string;
}
