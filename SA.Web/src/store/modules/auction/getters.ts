import { GetterTree } from 'vuex';

import { RootState, AuctionState } from '@/store/types';
import { AuctionTableDto, AuctionLookupDto, AuctionDto } from '@/poco';

const getters: GetterTree<AuctionState, RootState> = {
    /**
     *
     * @param state
     */
    getTableAuctions(state): AuctionTableDto[] {
        const { auctionsTable } = state;
        return auctionsTable;
    },
    getLookupList(state): AuctionLookupDto[] {
        const { lookupList } = state;
        return lookupList;
    },
    getAuctions(state): AuctionDto[] {
        const { auctions } = state;
        return auctions;
    },
};

export default getters;
