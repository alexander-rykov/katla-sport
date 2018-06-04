import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HiveSectionListItem } from '../models/hive-section-list-item';
import { HiveService } from '../services/hive.service';
import { HiveSectionService } from '../services/hive-section.service';

@Component({
  selector: 'app-hive-section-list',
  templateUrl: './hive-section-list.component.html',
  styleUrls: ['./hive-section-list.component.css']
})
export class HiveSectionListComponent implements OnInit {

  hiveId: number;
  hiveSections: Array<HiveSectionListItem>;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private hiveService: HiveService,
    private hiveSectionService: HiveSectionService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(p => {
      this.hiveId = p['id'];
      this.hiveService.getHiveSections(this.hiveId).subscribe(s => this.hiveSections = s);
    })
  }

  onDelete(hiveId: number) {
    var hiveSection = this.hiveSections.find(h => h.id == hiveId);
    this.hiveSectionService.setHiveSectionStatus(hiveId, true).subscribe(c => hiveSection.isDeleted = true);
  }

  onRestore(hiveId: number) {
    var hiveSection = this.hiveSections.find(h => h.id == hiveId);
    this.hiveSectionService.setHiveSectionStatus(hiveId, false).subscribe(c => hiveSection.isDeleted = false);
  }
}
