import { SportEvent } from './sport.event.model';

export interface PageResponse<T> {
    pageNumber: number,
    pageSize: number,
    data: T[]
}
