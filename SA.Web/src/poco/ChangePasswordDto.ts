export default interface ChangePasswordDto {
    oldPassword: string;
    repeatOldPassword: string;
    newPassword: string;
    token: string;
}
