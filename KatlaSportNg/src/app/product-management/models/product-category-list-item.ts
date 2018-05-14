export class ProductCategoryListItem {
    constructor(
        public id: number,
        public name: string,
        public code: string,
        public productCount: number,
        public isDeleted: boolean
    ) { }
}
