export class ProductCategory {
    constructor(
        public id: number,
        public name: string,
        public code: string,
        public description: string,
        public isDeleted: boolean,
        public lastUpdated: string
    ) { }
}
