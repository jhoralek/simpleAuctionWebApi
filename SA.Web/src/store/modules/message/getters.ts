import { GetterTree } from 'vuex';

import { MessageDto } from '@/poco';
import { RootState, MessageState } from '@/store/types';

const getters: GetterTree<MessageState, RootState> = {
    /**
     * Get the inner message from message envelope
     * @param state State of the message
     */
    getMessage(state): MessageDto {
        const { message } = state;
        return message;
    },
};

export default getters;
