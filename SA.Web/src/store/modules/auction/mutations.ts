import { MutationTree } from 'vuex';

import { AuctionState } from '@/store/types';
import { AuctionDto, AuctionTableDto } from '@/poco';
import { Auction } from '@/model';

const mutations: MutationTree<AuctionState> = {
    /**
     * Initialization of the state
     * @param state Auction state
     */
    AUTH_INITIAL_STATE(state) {
        state.auctions = [] as AuctionDto[];
        state.auctionsTable = [] as AuctionTableDto[];
        state.current = undefined;
    },
    AUCTION_CHANGE_CURRENT_STATE(state, auction: Auction) {
        state.current = auction;

        if (auction !== null && auction.validFrom !== null) {
            state.current.validFrom = new Date(auction.validFrom);
        }
        if (auction !== null && auction.validTo !== null) {
            state.current.validTo = new Date(auction.validTo);
        }
    },
    AUCTION_INITIAL_CURRENT(state) {
        state.current = {
            isActive: false,
            isEnded: false,
            created: new Date(),
        } as Auction;
    },
    AUCTION_CHANGE_TABLE_STATE(state, auctions: AuctionTableDto[]) {
        state.auctionsTable = auctions;
    },
    AUCTION_DELETE_RECORD_FROM_LIST(state, auction: Auction) {
        if (state.auctionsTable !== undefined && state.auctionsTable.length > 0) {
            state.auctionsTable = state.auctionsTable
                .filter((item) => item.id !== auction.id);
        }
        if (state.auctions !== undefined && state.auctions.length > 0) {
            state.auctions = state.auctions
                .filter((item) => item.id !== auction.id);
        }
    },
};

export default mutations;
