import { IProduct } from "./product";

export interface IPagination {
    data: IProduct[];
    pageNumber: number;
    pageSize: number;
    totalCount: number;
}