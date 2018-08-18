export enum GdprApplicationType {
    correctionPersonalInformation = 0, // oprava osobnich udaju
    deletingPersonalInformation = 1, // smazani osobnich udaju
    reportPersonalInformation = 2, // vypis osobnich udaju
    newObjection = 3, // vzneseni namitky
}

export default {
    GdprApplicationType,
};
