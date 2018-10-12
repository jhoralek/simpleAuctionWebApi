import CarouselItemDto from './CarouselItemDto';

export default interface CarouselDto {
    id?: number;
    name?: string;
    validFrom?: Date;
    validTo?: Date;
    items: CarouselItemDto[];
}
