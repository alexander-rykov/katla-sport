import { Component, OnInit } from '@angular/core';
import { HiveSectionProductListItem } from 'app/hive-management/models/hive-section-product-list-item';
import { ActivatedRoute, Router } from '@angular/router';
import { HiveService } from 'app/hive-management/services/hive.service';

@Component({
  selector: 'app-hive-section-product-list',
  templateUrl: './hive-section-product-list.component.html',
  styleUrls: ['./hive-section-product-list.component.css']
})
export class HiveSectionProductListComponent implements OnInit {

  sectionId: number;
  sectionProducts: HiveSectionProductListItem[];
  hiveId: number;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private productService: HiveService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(p => {
      this.sectionId = p['id'];
      this.hiveId = p['hiveId'];
      this.productService.getSectionProducts(p['id']).subscribe(p => this.sectionProducts = p);
    });
  }
  navigateToSections() {
    this.router.navigate([`hive/${this.hiveId}/sections`]);
  }
}
