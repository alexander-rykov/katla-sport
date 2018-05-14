export class ProductListItem {
    constructor(
        public id: number,
        public code: string,
        public name: string,
        public isDeleted: boolean,
        public categoryCode: string,
        public categoryId: number
    ) { }
}
