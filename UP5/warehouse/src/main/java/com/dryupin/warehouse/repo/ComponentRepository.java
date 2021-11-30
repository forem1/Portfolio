package com.dryupin.warehouse.repo;

import com.dryupin.warehouse.models.Component;
import com.dryupin.warehouse.models.Component_Category;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.query.Param;

public interface ComponentRepository extends CrudRepository<Component, Long> {
    @Query("select c from Component c where c.ComponentGroupId = :#{#GroupId}")
    Iterable<Component> GetComponentByGroupId(@Param("GroupId") String GroupId);
}
