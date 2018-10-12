import { GetterTree } from 'vuex';

import { RootState, AuctionState } from '@/store/types';
import {
    AuctionTableDto,
    AuctionLookupDto,
    AuctionDto,
    CarouselDto,
    CarouselItemDto,
} from '@/poco';

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
    getAuctionsCarousel(state): CarouselDto[] {
        const { auctions } = state;

        if (auctions.length > 0) {
            return auctions.map((item) => {
                return {
                    id: item.id,
                    name: item.name,
                    validFrom: item.validFrom,
                    validTo: item.validTo,
                    items: item.records.map((rec) => {
                        return {
                            id: rec.id,
                            name: rec.name,
                            imageUrl: rec.files.length > 0
                                    ? `/${rec.files[0].path}/${rec.files[0].recordId}/images/${rec.files[0].name}`
                                    : undefined,
                            price: rec.currentPrice,
                            withVat: rec.withVat,
                            info1: `${rec.registrationYear}`,
                            info2: rec.fuel,
                            info3: rec.mileage,
                        } as CarouselItemDto;
                    }),
                } as CarouselDto;
            });
        }
        return [] as CarouselDto[];
    },
};

export default getters;
