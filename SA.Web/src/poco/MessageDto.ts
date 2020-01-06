import { MessageStatusEnum } from "@/model";

export default interface MessageDto {
  state: MessageStatusEnum;
  message: string;
}
