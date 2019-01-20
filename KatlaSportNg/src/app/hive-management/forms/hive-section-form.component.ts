import { Component, OnInit } from '@angular/core';
import { HiveSection } from '../models/hive-section';
import { ActivatedRoute, Router } from '@angular/router';
import { HiveSectionService } from '../services/hive-section.service';
import { HiveSectionListItem } from '../models/hive-section-list-item';

@Component({
  selector: 'app-hive-section-form',
  templateUrl: './hive-section-form.component.html',
  styleUrls: ['./hive-section-form.component.css']
})
export class HiveSectionFormComponent implements OnInit {

  section = new HiveSection(0, 0, "Add new section name", "SOME1", false, "");
  existed = false;
  hiveId: number;
  hiveSections: Array<HiveSectionListItem>;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private sectionService: HiveSectionService,
  ) { }

  ngOnInit() {
    this.sectionService.getHiveSections().subscribe(s => this.hiveSections = s);
    this.route.params.subscribe(p => {
      this.hiveId = p['hiveId'];
      this.section.storeHiveId = p['hiveId'];
      if (p['id'] === undefined) return;
      this.sectionService.getHiveSection(p['id']).subscribe(s => this.section = s);
      this.existed = true;
    })
  }
  navigateTo() {
    if (this.hiveId === undefined) {
      this.router.navigate(['/hives']);
    } else {
      this.router.navigate([`/hive/${this.hiveId}/sections`]);
    }
  }

  onSubmit() {
    if (this.existed) {
      this.sectionService.updateHiveSection(this.section).subscribe(c => this.navigateTo());
    } else {
      this.sectionService.addHiveSection(this.section).subscribe(c => this.navigateTo());
    }
  }

  onDelete() {
    this.sectionService.setHiveSectionStatus(this.section.id, true).subscribe(c => this.section.isDeleted = true);
  }

  onUndelete() {
    this.sectionService.setHiveSectionStatus(this.section.id, false).subscribe(c => this.section.isDeleted = false);
  }

  onPurge() {
    this.sectionService.deleteHiveSection(this.section.id).subscribe(c => this.navigateTo());
  }
}