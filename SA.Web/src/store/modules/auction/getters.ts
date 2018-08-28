import { GetterTree } from 'vuex';

import { RootState, AuctionState } from '@/store/types';
import { AuctionTableDto } from '@/poco';

const getters: GetterTree<AuctionState, RootState> = {
    /**
     *
     * @param state
     */
    getAuctions(state): AuctionTableDto[] {
        const { auctionsTable } = state;
        return auctionsTable;
    },
};

export default getters;
