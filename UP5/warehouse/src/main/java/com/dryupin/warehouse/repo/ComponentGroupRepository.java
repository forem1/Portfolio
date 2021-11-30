package com.dryupin.warehouse.repo;

import com.dryupin.warehouse.models.Component_Category;
import com.dryupin.warehouse.models.Component_Group;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.query.Param;

public interface ComponentGroupRepository extends CrudRepository<Component_Group, Long> {
    @Query("select g from Component_Group g where g.componentGroupCategoryId = :#{#CategoryId}")
    Iterable<Component_Group> GetComponentGroupByCategoryId(@Param("CategoryId") String CategoryId);
}
